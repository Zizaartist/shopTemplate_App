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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Click.ViewModels
{
    public class CategoryViewModel : CollectionViewModel
    {
        public ObservableRangeCollection<CategoryLocal> Categories { get; } = new ObservableRangeCollection<CategoryLocal>();

        private Brand brand;

        public CategoryViewModel(Brand _brand)
        {
            brand = _brand;

            GetInitialData = NewAsyncCommand(GetInitial);
        }

        public async Task GetInitial()
        {
            try
            {
                HttpClient client = await createUserClient();

                //Получение всех меню по id бренда
                HttpResponseMessage response = await client.GetAsync(ApiStrings.HOST +
                                                                        ApiStrings.CATEGORIES_GET_BY_BRAND + brand.BrandId);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    List<Category> tempList = JsonConvert.DeserializeObject<List<Category>>(result);
                    tempList.ForEach(e => e.Brand = brand);

                    Categories.Clear();

                    var localizedList = new List<CategoryLocal>();
                    foreach (var item in tempList)
                    {
                        localizedList.Add(new CategoryLocal(item));
                    }
                    Categories.AddRange(localizedList);

                    await BlobCache.LocalMachine.InsertObject(Caches.CATEGORIES_CACHE.key + "_" +
                                                                brand.Kind.ToString() + "_" +
                                                                brand.BrandId.ToString(), tempList, Caches.CATEGORIES_CACHE.lifeTime);
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
            finally 
            {
                IsWorking = false;
            }
        }

        public async Task GetCachedData() 
        {
            //Пытаемся вытащить данные из кэша, при неудаче создаем пустую ячейку для предотвращения KeyNotFoundException
            List<Category> cachedMenus = await new CacheFunctions().tryToGet<List<Category>>(Caches.CATEGORIES_CACHE.key + "_" +
                                                                            brand.Kind.ToString() + "_" +
                                                                            brand.BrandId.ToString(), CacheFunctions.BlobCaches.LocalMachine);

            Categories.Clear();

            //В случае если кэш не пуст
            if (cachedMenus != null)
            {
                var localizedList = new List<CategoryLocal>();
                foreach (var item in cachedMenus)
                {
                    localizedList.Add(new CategoryLocal(item));
                }
                Categories.AddRange(localizedList);
            }
            //В случае если он пуст
            else
            {
                try
                {
                    await GetInitialData.ExecuteAsync();
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
