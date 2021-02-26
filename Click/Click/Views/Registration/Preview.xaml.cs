using Akavache;
using Click.StaticValues;
using Click.ViewModels;
using Click.Views.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.Registration
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Preview : ContentPage
    {
        private enum AuthResult 
        {
            success,
            registration,
            error
        }

        public Preview()
        {
            InitializeComponent();

            Task.Run(() => NewPage());
        }

        protected async override void OnAppearing()
        {
            switch (await Authorize())
            {
                case AuthResult.success:
                    App.Current.MainPage = new NavigationPage(new Main());
                    break;
                case AuthResult.registration:
                    App.Current.MainPage = new NavigationPage(new Number());
                    break;
                case AuthResult.error:
                    bool response = DisplayAlert("Click", AlertMessages.UNEXPECTED_ERROR, null, "Понятно").Result;
                    break;
            }

            base.OnAppearing();
        }

        async Task NewPage()
        {
            logo.Opacity = 0;
            await logo.FadeTo(1, 3000);
        }

        private async Task<AuthResult> Authorize()
        {
            TokenFunctions authentificator = new TokenFunctions();
            CacheFunctions cacheManager = new CacheFunctions();

            try
            {
                if (await cacheManager.firstTimeLaunchCheck())
                {
                    int numberOfAttempts = 3; //attempts to log-in before throwing an error
                    var phone = await BlobCache.Secure.GetObject<string>(Caches.PHONE_CACHE.key);

                    for (int i = 1; i <= numberOfAttempts; i++)
                    {
                        var response = await authentificator.validateUser();

                        if (!response.IsSuccessStatusCode)
                        {
                            switch (response.StatusCode)
                            {
                                //Не зареган
                                case HttpStatusCode.NotFound:
                                    {
                                        return AuthResult.registration;
                                    }
                                case HttpStatusCode.Unauthorized:
                                    {
                                        HttpResponseMessage response_token = await authentificator.requestUserToken();
                                        if (!response_token.IsSuccessStatusCode)
                                        {
                                            return AuthResult.error; //Невозможно получить токен юзера - критическая ошибка
                                        }
                                        authentificator.writeToken(response_token);
                                        break;
                                    }
                                default: return AuthResult.error; //Необработанная ошибка сервера
                            }
                        }
                        else
                        {
                            return AuthResult.success; //единственный случай успешного исхода
                        }
                    }
                }

                //Попыток авторизации не осталось
                return AuthResult.error;
            }
            catch
            {
                return AuthResult.error; //Необработанная ошибка
            }
        }
    }
}