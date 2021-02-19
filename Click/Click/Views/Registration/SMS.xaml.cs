using Click.Views.User;
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
    public partial class SMS : ContentPage
    {
        public SMS()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void Confirm_Clicked(object sender, EventArgs e)
        {
            if (!CheckOne.IsChecked)
            {
                DisplayAlertOpen();
            }
            else if (!CheckTwo.IsChecked)
            {
                DisplayAlertOpen();
            }
            else
            {
                App.Current.MainPage = new NavigationPage(new Main());
            }            
        }
        async void DisplayAlertOpen()
        {
            await DisplayAlert("Click", "Заполните все поля", "Понятно");
        }
    }
}