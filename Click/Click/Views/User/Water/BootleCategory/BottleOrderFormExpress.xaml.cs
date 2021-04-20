using ApiClick.Models;
using ApiClick.Models.EnumModels;
using Click.StaticValues;
using Click.ViewModels;
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
    public partial class BottleOrderFormExpress : ContentPage
    {
        private readonly WaterOrderViewModel waterOrderVM;
        private Dictionary<PaymentMethod, Button> PaymentMethodButtons;
        private App styleAccessor;

        public BottleOrderFormExpress()
        {
            InitializeComponent();

            styleAccessor = new App();

            PaymentMethodButtons = new Dictionary<PaymentMethod, Button>()
            {
                { PaymentMethod.cash, Cash },
                { PaymentMethod.card, Card },
                { PaymentMethod.online, CardOnline }
            };

            waterOrderVM = new WaterOrderViewModel(true, Kind.bottledWater);
            BindingContext = waterOrderVM;
            waterOrderVM.Autofill(UsersViewModel.Instance.User);

            //remove and block methods which aren't allowed
            var toRemove = new List<PaymentMethod>();
            foreach (var pmb in PaymentMethodButtons)
            {
                if (!waterOrderVM.AllowedPaymentMethods.Contains(pmb.Key))
                {
                    pmb.Value.IsEnabled = false;
                    toRemove.Add(pmb.Key);
                }
            }
            toRemove.ForEach(e => PaymentMethodButtons.Remove(e));
        }

        private void ChangePaymentMethod_Clicked(object sender, EventArgs e)
        {
            var selectedPM = PaymentMethodButtons.First(x => x.Value.Equals(sender));

            var initialPM = PaymentMethodButtons[waterOrderVM.PaymentMethod];

            selectedPM.Value.Style = styleAccessor.paymentSelected;
            initialPM.Style = styleAccessor.payment;

            waterOrderVM.PaymentMethod = selectedPM.Key;
        }

        private void Bonus_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BonusHistory());
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

        async private void Confirm_Clicked(object sender, EventArgs e)
        {
            var response = await waterOrderVM.PostOrder();
            if (response.IsSuccessStatusCode)
            {
                await Navigation.PushModalAsync(new BottleExpressWaiting());
            }
            else
            {
                await DisplayAlert("Ошибка", AlertMessages.UNEXPECTED_ERROR, "Понятно");
            }
        }
    }
}