using ApiClick.Models.EnumModels;
using Click.Models.LocalModels;
using Click.StaticValues;
using Click.ViewModels;

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
        private App styleAccessor;
        private OrderViewModel orderVM;
        private BasketViewModel basketVM;
        private Dictionary<PaymentMethod, Button> PaymentMethodButtons;

        public CourierForm(BasketViewModel _basketVM)
        {
            InitializeComponent();

            styleAccessor = new App();

            PaymentMethodButtons = new Dictionary<PaymentMethod, Button>()
            {
                { PaymentMethod.cash, Cash },
                { PaymentMethod.card, Card },
                { PaymentMethod.online, CardOnline }
            };

            basketVM = _basketVM;

            orderVM = new OrderViewModel(_basketVM.OrderDetails, true);
            BindingContext = orderVM;
            Task.Run(() => orderVM.Autofill());
        }

        private void ChangePaymentMethod_Clicked(object sender, EventArgs e)
        {
            var selectedPM = PaymentMethodButtons.First(x => x.Value.Equals(sender));

            var initialPM = PaymentMethodButtons[orderVM.PaymentMethod];

            selectedPM.Value.Style = styleAccessor.paymentSelected;
            initialPM.Style = styleAccessor.payment;

            orderVM.PaymentMethod = selectedPM.Key;
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        async private void Confirm_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Click","Вы действительно хотите осуществить заказ","Да","Нет");
            if (result)
            {
                var response = await orderVM.PostOrder();
                if (response.IsSuccessStatusCode)
                {
                    await basketVM.Clear();
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