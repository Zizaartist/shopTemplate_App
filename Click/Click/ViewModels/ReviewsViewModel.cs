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

        private string text;
        public string Text 
        {
            get => text;
            set { SetProperty(ref text, value); }
        }

        private int rating;
        public int Rating 
        {
            get => rating;
            set 
            {
                SetProperty(ref rating, value);
                OnPropertyChanged("IsReviewValid");
            }
        }

        public bool IsReviewValid { get => Rating > 0 && Rating <= 5; }

        private int allReviewsCount;
        public int AllReviewsCount 
        {
            get => allReviewsCount;
            set { SetProperty(ref allReviewsCount, value); }
        }

        private int textReviewsCount;
        public int TextReviewsCount
        {
            get => textReviewsCount;
            set { SetProperty(ref textReviewsCount, value); }
        }

        public Command ChangeRating { get; }

        private int? brandId;
        private int? orderId;

        #endregion

        public ReviewsViewModel(int? _brandId = null, int? _orderId = null) 
        {
            brandId = _brandId;
            orderId = _orderId;
            GetInitialData = NewAsyncCommand(GetInitial);
            GetMoreData = NewAsyncCommand(GetRemoteData);
            ChangeRating = new Command((param) => Rating = int.Parse(param as string));
        }

        public async Task GetInitial() 
        {
            Reviews.Clear();
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
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound) 
                {
                    NextPage = -1;
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

        public async Task<HttpResponseMessage> PostReview() 
        {
            try
            {
                HttpClient client = await createUserClient();

                var newReview = new Review() 
                {
                    OrderId = orderId,
                    Rating = Rating,
                    Text = Text
                };

                var serializedObj = SerializeIgnoreNull(newReview);
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
