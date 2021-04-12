using ApiClick.Models;
using Click.Models.LocalModels;
using Click.StaticValues;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Click.ViewModels
{
    public class ReviewsViewModel : CollectionViewModel
    {
        #region properties

        public ObservableCollection<ReviewLocal> Reviews { get; } = new ObservableCollection<ReviewLocal>();

        private int allReviewsCount;
        public int AllReviewsCount 
        {
            get => allReviewsCount;
            set 
            {
                if (allReviewsCount == value) return;
                allReviewsCount = value;
                OnPropertyChanged();
            }
        }

        private int textReviewsCount;
        public int TextReviewsCount
        {
            get => textReviewsCount;
            set
            {
                if (textReviewsCount == value) return;
                textReviewsCount = value;
                OnPropertyChanged();
            }
        }

        private int? brandId;

        #endregion

        public ReviewsViewModel(int? _brandId = null) 
        {
            brandId = _brandId;
            GetInitialData = NewGetDataCommand(GetInitial);
            GetMoreData = NewGetDataCommand(GetRemoteData);
        }

        public async Task GetInitial() 
        {
            Reviews.Clear();
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

        public async Task GetRemoteData()
        {
            try
            {
                HttpClient client = await createUserClient();

                //Получение всех брендов по id категории
                HttpResponseMessage response = await client.GetAsync(ApiStrings.HOST +
                                                                     ApiStrings.REVIEWS_GET_BY_BRAND + brandId + "/" + NextPage);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    List<Review> tempList = JsonConvert.DeserializeObject<List<Review>>(result);
                    if (tempList.Count != 0)
                    {
                        NextPage++;
                    }

                    foreach (var item in tempList)
                    {
                        Reviews.Add(new ReviewLocal(item));
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

        public async Task GetReviewCount()
        {
            try
            {
                HttpClient client = await createUserClient();

                //Получение всех брендов по id категории
                HttpResponseMessage response = await client.GetAsync(ApiStrings.HOST +
                                                                     ApiStrings.REVIEWS_GET_COUNT + brandId);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    (int, int) pair = JsonConvert.DeserializeObject<(int, int)>(result);
                    AllReviewsCount = pair.Item1;
                    TextReviewsCount = pair.Item2;
                }
                throw new Exception("Ошибка при получении количества отзывов");
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

        public async Task<HttpResponseMessage> PostReview(Review _review) 
        {
            try
            {
                HttpClient client = await createUserClient();
                var serializedObj = JsonConvert.SerializeObject(_review);
                var data = new StringContent(serializedObj, Encoding.UTF8, "application/json");
                return await client.PostAsync(ApiStrings.HOST + ApiStrings.REVIEWS_CONTROLLER, data);
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
