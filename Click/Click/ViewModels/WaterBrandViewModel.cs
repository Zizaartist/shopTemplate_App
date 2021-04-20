using Akavache;
using ApiClick.Models;
using Click.Models;
using Click.Models.LocalModels;
using Click.StaticValues;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class WaterBrandViewModel : ViewModel
    {
        public ObservableRangeCollection<WaterBrandLocal> WaterBrands { get; } = new ObservableRangeCollection<WaterBrandLocal>();

        private Kind kind;

        public WaterBrandViewModel(Kind _kind) 
        {
            kind = _kind;
        }

        public async Task GetRemoteData()
        {
            try
            {
                HttpClient client = await createUserClient();
                HttpResponseMessage response = await client.GetAsync(ApiStrings.HOST +
                                                                        ApiStrings.BRANDS_GET_WATER + (int)kind);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    List<Brand> tempList = JsonConvert.DeserializeObject<List<Brand>>(result);

                    var localizedList = new List<WaterBrandLocal>();
                    foreach (var item in tempList)
                    {
                        localizedList.Add(new WaterBrandLocal(item));
                    }
                    WaterBrands.AddRange(localizedList);

                    await BlobCache.LocalMachine.InsertObject(Caches.BRANDS_CACHE.key + "_" +
                                                              kind.ToString(), WaterBrands.Select(e => e.Brand), Caches.BRANDS_CACHE.lifeTime);
                }
            }
            catch (NoConnectionException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw CheckIfConnectionException(e);
            }
        }

        public async Task GetCachedData()
        {
            //Пытаемся вытащить данные из кэша, при неудаче создаем пустую ячейку для предотвращения KeyNotFoundException
            List<Brand> cachedBrands = await new CacheFunctions().tryToGet<List<Brand>>(Caches.BRANDS_CACHE.key + "_" +
                                                                                            kind.ToString(), CacheFunctions.BlobCaches.LocalMachine);

            WaterBrands.Clear();

            //В случае если кэш не пуст
            if (cachedBrands != null && cachedBrands.Any())
            {
                var localizedList = new List<WaterBrandLocal>();
                foreach (var brand in cachedBrands)
                {
                    localizedList.Add(new WaterBrandLocal(brand));
                }
                WaterBrands.AddRange(localizedList);
            }
            //В случае если он пуст
            else
            {
                try
                {
                    await GetRemoteData();
                }
                catch (NoConnectionException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    throw CheckIfConnectionException(e);
                }
            }
        }
    }
}
