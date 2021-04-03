using ApiClick.Models.ArrayModels;
using ApiClick.Models.EnumModels;
using Click.Models.LocalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Flowers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DescriptionOrganizationFlowers : ContentPage
    {
        public DescriptionOrganizationFlowers(BrandLocal _brandLocal)
        {
            InitializeComponent();

            BrandName.Text = _brandLocal.Brand.BrandName;
            Description.Text = _brandLocal.Brand.Description;
            DeliveryTerms.Text = _brandLocal.Brand.Rules;
            Contact.Text = _brandLocal.Brand.Contact;
            MinimalPrice.Text = _brandLocal.Brand.MinimalPrice.ToString();
            Banner.Source = _brandLocal.Banner;
            Logo.Source = _brandLocal.Logo;

            #region paymentMethods

            string paymentMethods = "";

            //Добавляем все доступные методы оплаты
            foreach (PaymentMethod paymentMethod in Enum.GetValues(typeof(PaymentMethod)))
            {
                if (_brandLocal.Brand.PaymentMethods.Contains(paymentMethod))
                {
                    paymentMethods += $", {PaymentMethodDictionaries.GetStringFromPaymentMethod[paymentMethod]}";
                }
            }

            paymentMethods = paymentMethods.Remove(0, 2);
            PaymentMethods.Text = paymentMethods[0].ToString().ToUpper() + paymentMethods.Substring(1).ToLower();

            #endregion

            #region schedule

            foreach (DayOfWeek dayOfWeek in DayOfWeekDictionaries.CorrectlyOrderedDays)
            {
                var found = _brandLocal.Brand.ScheduleListElements.FirstOrDefault(e => e.DayOfWeek == dayOfWeek);
                string addedText;
                if (found != null)
                {
                    addedText = $"{found.OpenTime.ToString(@"hh\:mm")} - {found.CloseTime.ToString(@"hh\:mm")}";
                }
                else
                {
                    addedText = $"Выходной";
                }
                Schedule.Spans.Add(new Span() { Text = $"{DayOfWeekDictionaries.GetStringFromDayOfWeek[dayOfWeek]} {addedText} \n" });
            }

            #endregion
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}