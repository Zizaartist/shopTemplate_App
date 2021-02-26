using Click.StaticValues;
using Click.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.Registration
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Number : ContentPage
    {
        RegistrationViewModel registrationVM = new RegistrationViewModel();
        TokenFunctions authentificator = new TokenFunctions();

        public Number()
        {
            InitializeComponent();
            BindingContext = registrationVM;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Confirm_Clicked(object sender, EventArgs e)
        {
            if ((await registrationVM.validatePhone()).IsSuccessStatusCode)
            {
                //Проверяем зареган ли такой телефон
                var authResponse = await authentificator.validateUser(registrationVM.CorrectPhone);
                bool alreadyRegistered;
                switch (authResponse.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        alreadyRegistered = false;
                        break;
                    case System.Net.HttpStatusCode.Unauthorized:
                    case System.Net.HttpStatusCode.OK: //Не должно быть здесь, но ок
                        alreadyRegistered = true;
                        break;
                    default:
                        alreadyRegistered = false;
                        break;
                }

                if ((await registrationVM.SmsCheck()).IsSuccessStatusCode)
                {
                    App.Current.MainPage = new NavigationPage(new SMS(registrationVM, alreadyRegistered));
                }
                else
                {
                    await DisplayAlert("Click", AlertMessages.UNEXPECTED_ERROR, "Понятно");
                }
            }
            else
            {
                await DisplayAlert("Click", AlertMessages.ERROR_NUMBER_IS_INVALID, "Понятно");
            }
        }
    }
}