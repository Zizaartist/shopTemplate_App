using Click.ViewModels;
using Click.Views.User.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Water.BootleCategory
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottleExpressWaiting : ContentPage
    {
        public BottleExpressWaiting()
        {
            InitializeComponent();
            OrderCollection.BindingContext = new OrderHistoryViewModel();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void OrderCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Any())
            {
                OrderCollection.SelectedItem = null;
                OrderCollection.IsVisible = false;
                StackReady.IsVisible = true;
            }
        }

        private void Confirm_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new OrdersMain();
        }
    }
}