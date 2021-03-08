using Akavache;
using ApiClick.Models;
using Click.Models;
using Click.Models.LocalModels;
using Click.StaticValues;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Click.ViewModels
{
    public class BrandMenuViewModel : CollectionViewModel
    {
        public ObservableCollection<BrandMenuLocal> BrandMenus { get; } = new ObservableCollection<BrandMenuLocal>();

        private Brand brand;

        public BrandMenuViewModel(Brand _brand)
        {
            brand = _brand;

            GetInitialData = new GetDataCommand(async () => await GetInitial(), value => GetDataLock = value, () => GetDataLock);
        }

        public async Task GetInitial()
        {
            try
            {
                HttpClient client = await createUserClient();

                //Получение всех меню по id бренда
                HttpResponseMessage response = await client.GetAsync(ApiStrings.API_HOST + "api/" +
                                                                        ApiStrings.API_MENU_GET_BY_BRAND + brand.BrandId);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    List<BrandMenu> tempList = JsonConvert.DeserializeObject<List<BrandMenu>>(result);
                    tempList.ForEach(e => e.Brand = brand);

                    BrandMenus.Clear();

                    foreach (var item in tempList)
                    {
                        BrandMenus.Add(new BrandMenuLocal(item));
                    }

                    await BlobCache.LocalMachine.InsertObject(Caches.MENUS_CACHE.key + "_" +
                                                                brand.Category.ToString() + "_" +
                                                                brand.BrandId.ToString(), tempList, Caches.MENUS_CACHE.lifeTime);
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
            List<BrandMenu> cachedMenus = await new CacheFunctions().tryToGet<List<BrandMenu>>(Caches.MENUS_CACHE.key + "_" +
                                                                            brand.Category.ToString() + "_" +
                                                                            brand.BrandId.ToString(), CacheFunctions.BlobCaches.LocalMachine);

            BrandMenus.Clear();

            //В случае если кэш не пуст
            if (cachedMenus != null)
            {
                foreach (BrandMenu menu in cachedMenus)
                {
                    BrandMenus.Add(new BrandMenuLocal(menu));
                }
            }
            //В случае если он пуст
            else
            {
                try
                {
                    GetInitialData.Execute(null);
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
