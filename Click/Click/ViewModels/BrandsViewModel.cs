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
using System.Diagnostics;

namespace Click.ViewModels
{
    public class BrandsViewModel : CollectionViewModel
    {
        #region properties

        public ObservableRangeCollection<BrandLocal> Brands { get; } = new ObservableRangeCollection<BrandLocal>();

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
                Task.Run(async () => await GetInitialData.ExecuteAsync());
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

                SelectedHashtags.CollectionChanged += (sender, e) =>
                {
                    Task.Run(async () => await GetInitialData.ExecuteAsync());
                }; //При любом изменении коллекции выбранных хэштегов запрашивать данные
            }

            GetInitialData = NewAsyncCommand(GetInitial);
            if (_nameSearchMode)
            {
                GetMoreData = NewAsyncCommand(GetDataByName);
            }
            else
            {
                GetMoreData = NewAsyncCommand(GetRemoteData);
            }
        }

        public async Task GetInitial()
        {
            Brands.Clear();
            NextPage = 0;

            try
            {
                await GetMoreData.ExecuteAsync();
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
            await Task.Delay(2000);
            if (IsLastPageReached) return;
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

                    if (tempList.Count != 0)
                    {
                        NextPage++;
                    }

                    var localizedList = new List<BrandLocal>();
                    foreach (var item in tempList)
                    {
                        localizedList.Add(new BrandLocal(item));
                    }
                    Brands.AddRange(localizedList);

                    await BlobCache.LocalMachine.InsertObject(Caches.BRANDS_CACHE.key + "_" +
                                                              kind.ToString(), (NextPage, Brands.Select(e => e.Brand)), Caches.BRANDS_CACHE.lifeTime);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    NextPage = -1; //last page reached
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
            (int, List<Brand>) cachedBrands = await new CacheFunctions().tryToGet<(int, List<Brand>)>(Caches.BRANDS_CACHE.key + "_" +
                                                                                            kind.ToString(), CacheFunctions.BlobCaches.LocalMachine);

            Brands.Clear();

            //В случае если кэш не пуст
            if (cachedBrands != default)
            {
                var localizedList = new List<BrandLocal>();
                foreach (Brand brand in cachedBrands.Item2)
                {
                    localizedList.Add(new BrandLocal(brand));
                }
                Brands.AddRange(localizedList);

                NextPage = cachedBrands.Item1;
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

                    var localizedList = new List<BrandLocal>();
                    foreach (var item in tempList)
                    {
                        localizedList.Add(new BrandLocal(item));
                    }
                    Brands.AddRange(localizedList);
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

        public async Task<Brand> GetSpecificData(int _brandId)
        {
            try
            {
                HttpClient client = await createUserClient();

                //Отправляем список хэштегов, даже будучи пустым
                HttpResponseMessage response = await client.GetAsync(ApiStrings.HOST +
                                                                        ApiStrings.BRANDS_CONTROLLER + _brandId);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Brand temp = JsonConvert.DeserializeObject<Brand>(result);

                    return temp;
                }
                return null;
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
