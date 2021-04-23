using Click.Models.LocalModels;
using Click.ViewModels;
using Click.Views.User.Food;
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

        private void OrderButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BasketChoice(basketVM));
        }

        private void ProfileButton_Clicked(object sender, EventArgs e)
        {
            Navigation.teleportTo(new ProfileMain());
        }

        private void BasketButton_Clicked(object sender, EventArgs e)
        {

        }

        private void OrdersButton_Clicked(object sender, EventArgs e)
        {
            Navigation.teleportTo(new OrdersMain());
        }

        private void MainButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }
    }
}