using ApiClick.Models;
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
    public class MessagesViewModel : CollectionViewModel
    {
        #region properties

        public ObservableCollection<Message> Messages { get; } = new ObservableCollection<Message>();

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

        //Пагинация
        public int Page { get; private set; } = 0;
        private bool GetMoreDataLock;
        private bool GetInitialDataLock;
        public int ItemTreshold { get; } = 1;
        public Command GetMoreData { get; protected set; }
        public Command GetInitialData { get; protected set; }

        private int? brandId;

        #endregion

        public MessagesViewModel(int? _brandId = null) 
        {
            brandId = _brandId;
            GetMoreData = new Command(() => GetMoreReviews());
            GetInitialData = new Command(() => GetInitial());
        }

        public async Task GetInitial() 
        {
            Messages.Clear();
            Page = 0;

            try
            {
                GetMoreData.Execute(null);
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

        public async Task GetMoreReviews()
        {
            if (GetMoreDataLock) return;
            GetMoreDataLock = true;

            try
            {
                HttpClient client = await createUserClient();

                //Получение всех брендов по id категории
                HttpResponseMessage response = await client.GetAsync(ApiStrings.API_HOST + "api/" +
                                                                     ApiStrings.API_MESSAGES_GET_BY_BRAND + brandId + "/" + Page);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    List<Message> tempList = JsonConvert.DeserializeObject<List<Message>>(result);
                    if (tempList.Count != 0)
                    {
                        Page++;
                    }

                    foreach (var item in tempList)
                    {
                        Messages.Add(item);
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
            finally
            {
                GetMoreDataLock = false;
            }
        }

        public async Task GetReviewCount()
        {
            try
            {
                HttpClient client = await createUserClient();

                //Получение всех брендов по id категории
                HttpResponseMessage response = await client.GetAsync(ApiStrings.API_HOST + "api/" +
                                                                     ApiStrings.API_MESSAGES_GET_COUNT + brandId);
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

        public async Task<HttpResponseMessage> PostReview(Message _review) 
        {
            try
            {
                HttpClient client = await createUserClient();
                var serializedObj = JsonConvert.SerializeObject(_review);
                var data = new StringContent(serializedObj, Encoding.UTF8, "application/json");
                return await client.PostAsync(ApiStrings.API_HOST + "api/" + ApiStrings.API_MESSAGES_CONTROLLER, data);
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
