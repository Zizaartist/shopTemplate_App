using Click.Models.LocalModels;
using Click.StaticValues;
using Click.ViewModels;
using Click.Views.Registration;
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

        private async void OrderButton_Clicked(object sender, EventArgs e)
        {
            CacheFunctions cache = new CacheFunctions();

            string qew = await cache.tryToGet<string>(Caches.TOKENTYPE_CACHE.key, CacheFunctions.BlobCaches.Secure);
            if (qew == "Default")
            {
                await Navigation.PushAsync(new Number());
            }
            else
            {
                await Navigation.PushAsync(new BasketChoice(basketVM));
            }
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