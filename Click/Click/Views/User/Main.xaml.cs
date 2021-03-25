using Click.ViewModels;
using Click.Views.User.Basket;
using Click.Views.User.Flowers;
using Click.Views.User.Food;
using Click.Views.User.Orders;
using Click.Views.User.Water;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : ContentPage
    {
        public Main()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            AdCollection.BindingContext = new AdBannerViewModel();
        }

        private void Food_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainFood());
        }

        private void Water_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainWater());
        }

        private void Flowers_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainFlowers());
        }

        private void Profile_Clicked(object sender, EventArgs e)
        {

        }

        private void Basket_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new BasketMain();
        }

        private void Orders_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new OrdersMain();
        }

        private void Main_Clicked(object sender, EventArgs e)
        {

        }
    }
}