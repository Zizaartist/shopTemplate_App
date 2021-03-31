using Click.Views.User.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Water.WaterCarCategory
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WaterCarForm : ContentPage
    {
        public WaterCarForm()
        {
            InitializeComponent();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Bonus_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BonusHistory());
        }

        async private void Confirm_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Click", "Вы действительно хотите осуществить заказ", "Да", "Нет");
            if (result)
            {
                await DisplayAlert("Click", "Заказ осуществлен, ожидайте", "Понятно");
                App.Current.MainPage = new OrdersMain();
            }
        }
        private void CardOnline_Clicked(object sender, EventArgs e)
        {
            App app = new App();
            ClearMethodPayment();
            CardOnline.Style = app.paymentSelected;
        }

        private void Card_Clicked(object sender, EventArgs e)
        {
            App app = new App();
            ClearMethodPayment();
            Card.Style = app.paymentSelected;
        }

        private void Cash_Clicked(object sender, EventArgs e)
        {
            App app = new App();
            ClearMethodPayment();
            Cash.Style = app.paymentSelected;
        }
        void ClearMethodPayment()
        {
            App app = new App();
            Cash.Style = app.payment;
            CardOnline.Style = app.payment;
            Card.Style = app.payment;
        }
    }
}