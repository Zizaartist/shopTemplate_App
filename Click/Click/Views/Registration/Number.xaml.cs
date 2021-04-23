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
        }

        private async void Confirm_Clicked(object sender, EventArgs e)
        {
            if ((await registrationVM.SmsCheck()).IsSuccessStatusCode)
            {
                await Navigation.PushAsync(new SMS(registrationVM));
                var thisPage = Navigation.NavigationStack[Navigation.NavigationStack.Count - 2];
                Navigation.RemovePage(thisPage);
            }
            else
            {
                await  DisplayAlert("Click", AlertMessages.UNEXPECTED_ERROR, "Понятно");
            }
        }
    }
}