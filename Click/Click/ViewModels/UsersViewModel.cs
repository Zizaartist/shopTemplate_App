using ApiClick.Models;
using Akavache;
using Click.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Forms;
using System.Reactive.Linq;
using Xamarin.Forms.Xaml;
using Click.StaticValues;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Click.ViewModels
{
    public class UsersViewModel : ViewModel //Слишком часто юзается, придется делать синглтон
    {
        private static object syncRoot = new Object();
        private static UsersViewModel instance;
        public static UsersViewModel Instance 
        {
            get 
            {
                if (instance == null) 
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new UsersViewModel();
                        }
                    }
                }
                    
                return instance;
            }
        }

        private decimal points = 0m;
        public decimal Points 
        {
            get => points;
            set 
            {
                if (points == value) return;
                points = value;
                OnPropertyChanged();
            }
        }

        private User user;
        public User User
        {
            get => user;
            set
            {
                if (value == user) return;
                user = value;
                OnPropertyChanged();
            }
        }

        public async Task GetPoints()
        {
            try
            {
                HttpClient client = await createUserClient();

                var response = await client.GetAsync(ApiStrings.HOST +
                                                                     ApiStrings.USERS_POINTS);
                string result = await response.Content.ReadAsStringAsync();
                Points = JsonConvert.DeserializeObject<decimal>(result);
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

        public async Task<HttpResponseMessage> ChangeNumber(string newNumber, string code)
        {
            try
            {
                var client = await createUserClient();
                return await client.PutAsync(ApiStrings.HOST + ApiStrings.USERS_PHONE_CHANGE + "?newPhoneNumber=" + newNumber + "&code=" + code, null);
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

        public async Task GetData()
        {
            User = null;

            //Пытаемся вытащить данные из кэша, при неудаче создаем пустую ячейку для предотвращения KeyNotFoundException
            User cachedUser = await new CacheFunctions().tryToGet<User>(Caches.USER_CACHE.key, CacheFunctions.BlobCaches.UserAccount);

            //Если кэшированный пользователь найден - присваивание
            if (cachedUser != null)
            {
                User = cachedUser;
            }
            //В ином случае - получить от api и записать в кэш
            else
            {
                try
                {
                    HttpClient client = await createUserClient();

                    //Получение данных юзера по токену
                    HttpResponseMessage response = await client.GetAsync(ApiStrings.HOST +
                                                                         ApiStrings.USERS_MY_DATA);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        cachedUser = JsonConvert.DeserializeObject<User>(result);
                        User = cachedUser;
                        await BlobCache.UserAccount.InsertObject(Caches.USER_CACHE.key, cachedUser, Caches.USER_CACHE.lifeTime);
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
}
