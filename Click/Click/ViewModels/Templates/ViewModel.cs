using Akavache;
using Click.StaticValues;
using MvvmHelpers;
using Newtonsoft.Json;
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
    public abstract class ViewModel : BaseViewModel
    {
        protected static async Task<HttpClient> createUserClient() 
        {
            HttpClient client = HttpClientSingleton.Instance;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await new CacheFunctions().tryToGet<string>(Caches.TOKEN_CACHE.key, CacheFunctions.BlobCaches.Secure));
            return client;
        }

        protected string SerializeIgnoreNull(object _value) => JsonConvert.SerializeObject(_value,
            Formatting.Indented,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        public static bool isConnected 
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
        }

        //Возвращает NoConnectionException если нет подключения, иначе - изначальный exception
        protected Exception CheckIfConnectionException(Exception e)
        {
            return !isConnected ? new NoConnectionException() : e;
        }
    }
}
