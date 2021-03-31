using Click.Models;
using Click.ViewModels;
using Click.Views.User.Basket;
using Click.Views.User.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Orders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersMain : ContentPage
    {
        public OrdersMain()
        {
            InitializeComponent();
            OrderCollection.BindingContext = new OrderHistoryViewModel();
        }
        private void Profile_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfileMain();
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
            App.Current.MainPage = new Main();
        }

        private void OrderCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Any())
            {
                OrderCollection.SelectedItem = null;
                if ((e.CurrentSelection.LastOrDefault() as Order).Delivered == false)
                {
                    Navigation.PushModalAsync(new OrdersReview(e.CurrentSelection.LastOrDefault() as Order));
                }
            }
        }
    }
}