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
    public partial class CourierForm : ContentPage
    {
        
        public CourierForm()
        {
            InitializeComponent();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
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

        private void BonusSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (SumLabel.Text != "")
            {
                if (BonusSwitch.IsToggled == true)
                {
                    SumLabel.Text = (Convert.ToInt32(PayLabel.Text) - Convert.ToInt32(BonusLabel.Text)).ToString();
                }
                else
                {
                    SumLabel.Text = PayLabel.Text;
                }
            }
        }

        async private void Confirm_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Click","Вы действительно хотите осуществить заказ","Да","Нет");
            if (result)
            {
                await DisplayAlert("Click", "Заказ осуществлен, ожидайте", "Понятно");
                App.Current.MainPage = new Main();
            }
        }
    }
}