using Akavache;
using Click.StaticValues;
using Click.ViewModels;
using Click.Views.User;
using Click.Views.User.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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

            Task.Run(async () =>
            {
                switch (await Authorize())
                {
                    case AuthResult.success:
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            Task.Run(() => UsersViewModel.Instance.UpdatePoints.ExecuteAsync());
                            App.Current.MainPage = new NavigationPage(new CategoryCatalogue());
                        });
                        break;
                    case AuthResult.registration:
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            Task.Run(() => new AuthViewModel().GetDefaultToken());
                            App.Current.MainPage = new NavigationPage(new CategoryCatalogue());
                        });
                        break;
                    case AuthResult.error:
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            DisplayAlert("Error", AlertMessages.UNEXPECTED_ERROR, "Понятно");
                        });
                        //Выход из приложения
                        break;
                }
            });
            Task.Run(() => NewPage());
        }

        async Task NewPage()
        {
            logo.Opacity = 0;
            await logo.FadeTo(1, 3000);
        }

        private async Task<AuthResult> Authorize()
        {
            AuthViewModel authentificator = new AuthViewModel();
            CacheFunctions cacheManager = new CacheFunctions();

            try
            {
                if (await cacheManager.firstTimeLaunchCheck())
                {
                    var response = await authentificator.Validation();

                    if (!response.IsSuccessStatusCode)
                    {
                        switch (response.StatusCode)
                        {
                            case HttpStatusCode.Unauthorized:
                            {
                                return AuthResult.registration;
                            }
                            default: return AuthResult.error; //Необработанная ошибка сервера
                        }
                    }
                    else
                    {
                        return AuthResult.success; //единственный случай успешного исхода
                    }
                }
                return AuthResult.error; //Необработанная ошибка кэша
            }
            catch(Exception e)
            {
                return AuthResult.error; //Необработанная ошибка
            }
        }
    }
}