using System;
using Akavache;
using ApiClick.Models;
using Click.Models;
using Click.StaticValues;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using System.Reactive.Linq;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Click.Models.LocalModels;

namespace Click.ViewModels
{
    public class ProductListViewModel : CollectionViewModel
    {
        #region properties

        public ObservableCollection<ProductLocal> ProductLists { get; } = new ObservableCollection<ProductLocal>();

        public ProductLocal SelectedProduct { get; set; }
        public ProductLocal ProductSetter
        {
            get => null;
            set 
            {
                if (SelectedProduct != value)
                {
                    SelectedProduct = value;
                    OnPropertyChanged("SelectedProduct");
                } 
                OnPropertyChanged(); //Всегда сбрасывает обратно на null
            }
        }

        public int AddToCartCount { get => ProductLists.Sum(e => e.Count); }

        public bool AddToCartNotEmpty { get => ProductLists.Count > 0; }

        public decimal SumTotal { get => ProductLists.Sum(e => e.SumPrice); }

        private BrandMenu menu;

        #endregion

        #region methods

        public ProductListViewModel(BrandMenu _menu)
        {
            menu = _menu;

            GetInitialData = new GetDataCommand(async () => await GetInitial(), value => GetDataLock = value, () => GetDataLock);
            GetMoreData = new GetDataCommand(async () => await GetRemoteData(), value => GetDataLock = value, () => GetDataLock);
        }

        public async Task GetInitial()
        {
            ProductLists.Clear();
            Page = 0;

            try
            {
                await GetMoreData.ExecuteAsSubtask();
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

        public async Task GetRemoteData()
        {
            try
            {
                HttpClient client = await createUserClient();

                //Получение всех продуктов по id меню
                HttpResponseMessage response = await client.GetAsync(ApiStrings.API_HOST + "api/" +
                                                                        ApiStrings.API_PRODUCTS_GET_BY_MENU + menu.BrandMenuId + 
                                                                        "/" + Page);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    List<Product> tempList = JsonConvert.DeserializeObject<List<Product>>(result);
                    tempList.ForEach(e => e.BrandMenu = menu);

                    foreach (var item in tempList)
                    {
                        ProductLists.Add(new ProductLocal(item, UpdateBindings));
                    }

                    await BlobCache.LocalMachine.InsertObject(Caches.PRODUCTS_CACHE.key + "_" +
                                                                menu.Brand.Category.ToString() + "_" +
                                                                menu.Brand.BrandId.ToString() + "_" +
                                                                menu.BrandMenuId.ToString(), ProductLists.Select(e => e.Product), Caches.PRODUCTS_CACHE.lifeTime);
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
            List<Product> cachedProducts = await new CacheFunctions().tryToGet<List<Product>>(Caches.PRODUCTS_CACHE.key + "_" +
                                                                                                    menu.Brand.Category.ToString() + "_" +
                                                                                                    menu.Brand.BrandId.ToString() + "_" +
                                                                                                    menu.BrandMenuId.ToString(), CacheFunctions.BlobCaches.LocalMachine);

            ProductLists.Clear();

            //В случае если кэш не пуст
            if (cachedProducts != null)
            {
                foreach (Product product in cachedProducts)
                {
                    ProductLists.Add(new ProductLocal(product, UpdateBindings) { Product = product });
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

        public void UpdateBindings()
        {
            OnPropertyChanged("AddToCartCount");
            OnPropertyChanged("AddToCartNotEmpty");
            OnPropertyChanged("SumTotal");
        }

        #endregion
    }
}
