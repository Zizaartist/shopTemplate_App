using Akavache;
using Click.StaticValues;
using Click.ViewModels;
using Click.Views.User;
using Click.Views.User.Food;
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
        AuthViewModel registrationVM;

        public SMS(AuthViewModel _registractionVM)
        {
            InitializeComponent();
            registrationVM = _registractionVM;
            BindingContext = registrationVM;
        }

        private async void Confirm_Clicked(object sender, EventArgs e)
        {
            if (registrationVM.AllFieldsValid)
            {
                if ((await registrationVM.CodeCheck()).IsSuccessStatusCode)
                {
                    if ((await registrationVM.GetToken()).IsSuccessStatusCode)
                    {
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Click", AlertMessages.UNEXPECTED_ERROR, "Понятно");
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