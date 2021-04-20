using Akavache;
using Click.StaticValues;
using Click.ViewModels;
using Click.Views.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.Registration
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SMS : ContentPage
    {
        RegistrationViewModel registrationVM;
        private bool alreadyRegistered;

        public SMS(RegistrationViewModel _registractionVM, bool _alreadyRegistered)
        {
            InitializeComponent();
            registrationVM = _registractionVM;
            BindingContext = registrationVM;
            alreadyRegistered = _alreadyRegistered;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Confirm_Clicked(object sender, EventArgs e)
        {
            if (registrationVM.AllFieldsValid)
            {
                if ((await registrationVM.CodeCheck()).IsSuccessStatusCode)
                {
                    if (alreadyRegistered)
                    {
                        await BlobCache.Secure.InsertObject<string>(Caches.PHONE_CACHE.key, registrationVM.CorrectPhone);
                        await new TokenFunctions().requestUserToken();
                        App.Current.MainPage = new NavigationPage(new Main());
                    }
                    else
                    {
                        if ((await registrationVM.Registration()).IsSuccessStatusCode)
                        {
                            await BlobCache.Secure.InsertObject<string>(Caches.PHONE_CACHE.key, registrationVM.CorrectPhone);
                            await new TokenFunctions().requestUserToken();
                            App.Current.MainPage = new NavigationPage(new Main());
                        }
                        else
                        {
                            await DisplayAlert("Click", AlertMessages.UNEXPECTED_ERROR, "Понятно");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Click", AlertMessages.ERROR_CODE_IS_INVALID, "Понятно");
                }
            }
            else
            {
                await DisplayAlert("Click", AlertMessages.EMPTY_FIELDS, "Понятно");
            }
        }
    }
}