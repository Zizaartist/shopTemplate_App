using Click.Models.LocalModels;
using Click.ViewModels;
using Click.ViewModels.Help;
using Click.Views.User.Orders;
using Click.Views.User.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Basket
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasketMain : ContentPage
    {
        private readonly BasketViewModel basketVM;

        public BasketMain()
        {
            InitializeComponent();

            basketVM = new BasketViewModel();
            OrderCollection.BindingContext = basketVM;
            Task.Run(() => basketVM.GetData());
        }

        private void MainButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Main();
        }

        private void OrdersButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new OrdersMain();
        }

        private void BasketButton_Clicked(object sender, EventArgs e)
        {
            
        }

        private void ProfileButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfileMain();
        }

        private void Basket_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Navigation.PushModalAsync(new BasketChoice(button.BindingContext as Grouping<string, OrderDetailLocal>, basketVM));
        }
    }
}