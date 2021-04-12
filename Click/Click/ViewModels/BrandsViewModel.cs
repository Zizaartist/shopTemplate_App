using System;
using Akavache;
using ApiClick.Models;
using Click.Models;
using Click.StaticValues;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Specialized;
using Click.Models.LocalModels;
using MvvmHelpers;

namespace Click.ViewModels
{
    public class BrandsViewModel : CollectionViewModel
    {
        #region properties

        public ObservableCollection<BrandLocal> Brands { get; } = new ObservableCollection<BrandLocal>();

        private string nameCriteria;
        public string NameCriteria 
        {
            get => nameCriteria;
            set { SetProperty(ref nameCriteria, value); }
        }

        private bool isWorkingCriteria;
        public bool IsWorkingCriteria
        {
            get => isWorkingCriteria;
            set
            {
                if (isWorkingCriteria == value) return;
                isWorkingCriteria = value;
                OnPropertyChanged();
                GetInitialData.Execute(null);
            }
        }

        public ObservableCollection<HashtagLocal> SelectedHashtags;

        private Kind kind;

        #endregion

        public BrandsViewModel(Kind _kind, bool _nameSearchMode, ObservableCollection<HashtagLocal> _selectedHashtags = null)
        {
            kind = _kind;

            if (_selectedHashtags != null)
            {
                SelectedHashtags = _selectedHashtags;

                NotifyCollectionChangedEventHandler handler = (object sender, NotifyCollectionChangedEventArgs e) => GetInitialData.Execute(null);
                SelectedHashtags.CollectionChanged += handler; //При любом изменении коллекции выбранных хэштегов запрашивать данные
            }

            GetInitialData = NewGetDataCommand(GetInitial);
            if (_nameSearchMode)
            {
                GetMoreData = NewGetDataCommand(GetDataByName);
            }
            else
            {
                GetMoreData = NewGetDataCommand(GetRemoteData);
            }
        }

        public async Task GetInitial()
        {
            Brands.Clear();
            NextPage = 0;

            try
            {
                await GetMoreData.ExecuteAsSubTask();
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

        //Загружает бренды при смене критерия поиска
        public async Task GetRemoteData()
        {
            try
            {
                HttpClient client = await createUserClient();

                //Отправляем список хэштегов, даже будучи пустым
                var serializedObj = JsonConvert.SerializeObject(SelectedHashtags.Select(e => e.Hashtag.HashTagId).ToList());
                StringContent data = new StringContent(serializedObj, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(ApiStrings.HOST + 
                                                                        ApiStrings.BRANDS_GET_BY_FILTER + (int)kind +
                                                                        "/" + NextPage +
                                                                        "?openNow=" + (IsWorkingCriteria ? "true" : "false"), data);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    List<Brand> tempList = JsonConvert.DeserializeObject<List<Brand>>(result);

                    foreach (var item in tempList)
                    {
                        Brands.Add(new BrandLocal(item));
                    }

                    await BlobCache.LocalMachine.InsertObject(Caches.BRANDS_CACHE.key + "_" +
                                                              kind.ToString(), Brands.Select(e => e.Brand), Caches.BRANDS_CACHE.lifeTime);
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

            Brands.Clear();

            //В случае если кэш не пуст
            if (cachedBrands != null)
            {
                foreach (Brand brand in cachedBrands)
                {
                    Brands.Add(new BrandLocal(brand));
                }
            }
            //В случае если он пуст
            else
            {
                try
                {
                    await GetInitialData.ExecuteAsSubTask();
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

        //Без пагинации
        public async Task GetDataByName()
        {
            try
            {
                HttpClient client = await createUserClient();

                //Отправляем список хэштегов, даже будучи пустым
                HttpResponseMessage response = await client.GetAsync(ApiStrings.HOST +
                                                                        ApiStrings.BRANDS_GET_BY_NAME + (int)kind +
                                                                        (!string.IsNullOrEmpty(NameCriteria) ? $"?name={nameCriteria}" : ""));
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    List<Brand> tempList = JsonConvert.DeserializeObject<List<Brand>>(result);

                    foreach (var item in tempList)
                    {
                        Brands.Add(new BrandLocal(item));
                    }
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
    }
}
