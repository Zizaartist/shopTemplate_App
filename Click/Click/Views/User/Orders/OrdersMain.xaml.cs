using ApiClick.Models;
using Click.Models;
using Click.Models.LocalModels;
using Click.StaticValues;
using Click.ViewModels;
using Click.Views.User.Basket;
using Click.Views.User.Food;
using Click.Views.User.Profile;
using Newtonsoft.Json;
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
        private readonly OrderHistoryViewModel ordersVM;

        public OrdersMain()
        {
            InitializeComponent();

            ordersVM = new OrderHistoryViewModel();
            BindingContext = ordersVM;
            Task.Run(() => ordersVM.GetCachedData());
        }
        private void ProfileButton_Clicked(object sender, EventArgs e)
        {
            Navigation.teleportTo(new ProfileMain());
        }

        private void BasketButton_Clicked(object sender, EventArgs e)
        {
            Navigation.teleportTo(new BasketMain());
        }

        private void OrdersButton_Clicked(object sender, EventArgs e)
        {

        }

        private void MainButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
    }
}