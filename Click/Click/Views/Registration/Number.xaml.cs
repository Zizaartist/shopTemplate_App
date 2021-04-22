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
        AuthViewModel registrationVM = new AuthViewModel();

        public Number()
        {
            InitializeComponent();
            BindingContext = registrationVM;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Confirm_Clicked(object sender, EventArgs e)
        {
            if ((await registrationVM.SmsCheck()).IsSuccessStatusCode)
            {
                App.Current.MainPage = new NavigationPage(new SMS(registrationVM));
            }
            else
            {
                await DisplayAlert("Click", AlertMessages.UNEXPECTED_ERROR, "Понятно");
            }
        }
    }
}