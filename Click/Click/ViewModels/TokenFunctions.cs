using Akavache;
using Click.Models;
using Click.StaticValues;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Click.ViewModels
{
    /// <summary>
    /// Хранилище методов взаимодействующих с функциями api, связанными с авторизацией
    /// </summary>
    public class TokenFunctions : ViewModel
    {
        /// <summary>
        /// Производит проверку на валидность текущего токена и номера телефона
        /// </summary>
        /// <returns>Ответ API, содержащий код ошибки</returns>
        public async Task<HttpResponseMessage> validateUser()
        {
            try
            {
                HttpClient client = HttpClientSingleton.Instance;
                if (await BlobCache.Secure.GetObject<string>(Caches.TOKEN_CACHE.key) != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await BlobCache.Secure.GetObject<string>(Caches.TOKEN_CACHE.key));
                }

                var phone = await BlobCache.Secure.GetObject<string>(Caches.PHONE_CACHE.key);
                return await client.PostAsync(ApiStrings.HOST +
                                                ApiStrings.ACCOUNT_PHONE_CHECK +
                                                "?phone=" + phone ?? "", null);
            }
            catch (Exception e)
            {
                throw CheckIfConnectionException(e);
            }
        }

        /// <summary>
        /// Метод используемый при регистрации
        /// </summary>
        /// <param name="_phone"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> validateUser(string _phone)
        {
            try
            {
                HttpClient client = HttpClientSingleton.Instance;
                return await client.PostAsync(ApiStrings.HOST +
                                                ApiStrings.ACCOUNT_PHONE_CHECK +
                                                "?phone=" + _phone ?? "", null);
            }
            catch (Exception e)
            {
                throw CheckIfConnectionException(e);
            }
        }

        /// <summary>
        /// Запрашивает токен через API функцию UserToken
        /// </summary>
        /// <returns>Токен с правами пользователя</returns>
        public async Task<HttpResponseMessage> requestUserToken()
        {
            try
            {
                HttpClient client = HttpClientSingleton.Instance;

                return await client.PostAsync(ApiStrings.HOST +
                                                ApiStrings.ACCOUNT_USERS_TOKEN +
                                                "?phone=" + await BlobCache.Secure.GetObject<string>(Caches.PHONE_CACHE.key), null);
            }
            catch (Exception e)
            {
                throw CheckIfConnectionException(e);
            }
        }

        /// <summary>
        /// Запрашивает токен через API функцию AdminToken
        /// </summary>
        /// <returns>Токен с правами администратора</returns>
        public async Task<HttpResponseMessage> requestAdminToken(string login, string password)
        {
            try
            {
                HttpClient client = HttpClientSingleton.Instance;

                return await client.PostAsync(ApiStrings.HOST +
                                                ApiStrings.ACCOUNT_ADMINS_TOKEN +
                                                "?phone=" + await BlobCache.Secure.GetObject<string>(Caches.PHONE_CACHE.key) +
                                                "&login=" + login +
                                                "&password=" + password, null);
            }
            catch (Exception e)
            {
                throw CheckIfConnectionException(e);
            }
        }

        /// <summary>
        /// Десериализует ответ запроса и записывает полученный токен
        /// </summary>
        public async void writeToken(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            var tokenData = JsonConvert.DeserializeObject<TokenData>(content);

            await BlobCache.Secure.InsertObject<string>(Caches.TOKEN_CACHE.key, tokenData.access_token);
        }

        /// <summary>
        /// Проверяет валидность текущего токена пользователя и загружает новый в случае негодности
        /// </summary>
        public async Task checkAndRefreshToken()
        {
            try
            {
                var result = await validateUser();
                if (!(result).IsSuccessStatusCode)
                {
                    writeToken(await requestUserToken());
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
