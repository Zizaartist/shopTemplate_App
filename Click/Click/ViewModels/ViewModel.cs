using Akavache;
using Click.StaticValues;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Click.ViewModels
{
    //Создал чисто ради сокращения повторяемого кода
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected async Task<HttpClient> createUserClient() 
        {
            HttpClient client = new HttpClient();
            try 
            { 
                await new TokenFunctions().checkAndRefreshToken();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await BlobCache.Secure.GetObject<string>(Caches.TOKEN_CACHE.key));
                return client;
            }
            catch (Exception e)
            {
                throw CheckIfConnectionException(e);
            }
        }

        protected async Task<HttpClient> createAdminClient()
        {
            HttpClient client = new HttpClient();
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await BlobCache.Secure.GetObject<string>(Caches.TOKEN_CACHE.key));
                return client;
            }
            catch
            {
                throw;
            }
        }

        public bool isConnected 
        {
            get 
            {
                switch (Connectivity.NetworkAccess) 
                {
                    case NetworkAccess.Internet:
                    case NetworkAccess.ConstrainedInternet:
                        return true;
                    default:
                        return false;
                }
            }
            set
            {
                OnPropertyChanged(); //forces to update dependent views
            }
        }

        //Возвращает NoConnectionException если нет подключения, иначе - изначальный exception
        protected Exception CheckIfConnectionException(Exception e)
        {
            return !isConnected ? new NoConnectionException() : e;
        }

        //protected async Task<bool> tryToGetFromCache<T>(T container, string cacheKey, CacheFunctions.BlobCaches cacheType)
        //{
        //    //Сбраcываем содержимое
        //    container = default;

        //    //Пытаемся вытащить данные из кэша, при неудаче создаем пустую ячейку для предотвращения KeyNotFoundException
        //    T cachedObject = await new CacheFunctions().tryToGet<T>(cacheKey, cacheType);

        //    //Если кэшированный объект найден - присваивание
        //    if (cachedObject != null)
        //    {
        //        //Проверяем является ли тип наследуемым от ICollection
        //        if (cachedObject.GetType().GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICollection<>)))
        //        {
        //            foreach ()
        //            {
        //            }
        //        }
        //        else 
        //        {
        //            container = cachedObject;
        //        }
        //    }
        //}
    }
}
