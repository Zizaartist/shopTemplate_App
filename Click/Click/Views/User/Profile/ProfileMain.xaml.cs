using Click.Views.User.Basket;
using Click.Views.User.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileMain : ContentPage
    {
        public ProfileMain()
        {
            InitializeComponent();
        }

        private void BasketButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new BasketMain();
        }

        private void OrdersButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new OrdersMain();
        }

        private void MainButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Main();
        }
        private void AboutCompany(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AboutApplication());
        }

        private void EnterAdminCompany_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new EnterAdminCompany());
        }
    }
}