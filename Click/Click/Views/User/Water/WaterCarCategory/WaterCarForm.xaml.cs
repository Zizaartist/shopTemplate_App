using ApiClick.Models;
using ApiClick.Models.EnumModels;
using Click.Models.LocalModels;
using Click.StaticValues;
using Click.ViewModels;
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
        private readonly WaterOrderViewModel waterOrderVM;
        private Dictionary<PaymentMethod, Button> PaymentMethodButtons;
        private App styleAccessor;

        public WaterCarForm(WaterBrandLocal _brandData)
        {
            InitializeComponent();

            styleAccessor = new App();

            PaymentMethodButtons = new Dictionary<PaymentMethod, Button>()
            {
                { PaymentMethod.cash, Cash },
                { PaymentMethod.card, Card },
                { PaymentMethod.online, CardOnline }
            };

            waterOrderVM = new WaterOrderViewModel(false, Kind.water, _brandData);
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
            bool result = await DisplayAlert("Click", "Вы действительно хотите осуществить заказ?", "Да", "Нет");
            if (result)
            {
                var response = await waterOrderVM.PostOrder();
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Click", "Заказ осуществлен, ожидайте", "Понятно");

                    await Navigation.PopModalAsync();
                }
                else
                {
                    await DisplayAlert("Ошибка", AlertMessages.UNEXPECTED_ERROR, "Понятно");
                }
            }
        }
    }
}