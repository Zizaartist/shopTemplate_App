using Click.ViewModels;
using Click.Views.User.Orders;
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
        public BasketMain()
        {
            InitializeComponent();
            OrderCollection.BindingContext = new BasketViewModel();
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

        }

        private void Basket_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BasketChoice());
        }
    }
}