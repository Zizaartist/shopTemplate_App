using ApiClick.Models;
using Click.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.AdminCompany.Editor.FoodFlowers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditMain : ContentPage
    {
        Brand brand = new Brand();
        public EditMain()
        {
            InitializeComponent();
            brandinfo();
            string type = "food";
            stylesset(type);
            BindingContext = brand;
        }
        void stylesset(string type)
        {
            switch (type)
            {
                case "flowers":
                    Header.BackgroundColor = Color.FromHex("#3AB600");
                    DeliveryTime.TextColor = Color.FromHex("#3AB600");
                    FoodTime.Source = "FlowersTime.png";
                    break;
                case "food":
                    Header.BackgroundColor = Color.FromHex("#E65100");
                    DeliveryTime.TextColor = Color.FromHex("#E65100");
                    FoodTime.Source = "FoodTime.png";
                    break;
            }
        }
        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        void brandinfo()
        {
            //brand = new Brand()
            //{
            //    BrandInfo.Name = "Burger King",
            //    Tags = "бургеры фастфуд",
            //    Rating = "4.5",
            //    BankPayment = "BankCard.png",
            //    CashPayment = "Money.png",
            //    Discount = "Discount.png",
            //    Banner = "temp4.png",
            //    Logo = "temp5.png",
            //    DeliveryTime = "40 мин - 1ч 40 мин",
            //};
        }

        async private void NameEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите название организации");
            brand.BrandName = result;
        }

        async private void DescriptionEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите описание организации");
            brand.BrandName = result;
        }

        private void LogoGallery_Clicked(object sender, EventArgs e)
        {

        }

        private void BannerGallery_Clicked(object sender, EventArgs e)
        {

        }

        private void WorkTime_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new EditMainTimeWork());
        }

        private void TagsEdit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new EditMainTag());
        }

        async private void ConditionDeliveryEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите условия доставки");
            brand.BrandInfo.DeliveryTerms = result;
        }

        async private void ContactsEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите контакты организации");
            brand.BrandInfo.Contact = result;
        }

        async private void MinPriceEntry_Clicked(object sender, EventArgs e)
        {
            try
            {
                decimal result = Decimal.Parse(await DisplayPromptAsync("Click", "Введите мин. стоимость заказа"));
                brand.MinimalPrice = result;
            }
            catch (Exception _ex) 
            {
                //а хули мне с ним делать?
            }
        }

        private void CashPayment_Toggled(object sender, ToggledEventArgs e)
        {
            if (CashPayment.IsToggled)
            {
                //brand.CashPayment = "Money.png";
            }
            else
            {
                //brand.CashPayment = "";
            }
        }

        private void CardPayment_Toggled(object sender, ToggledEventArgs e)
        {
            if (CardPayment.IsToggled)
            {
                //brand.BankPayment = "BankCard.png";
            }
            else
            {
                //brand.BankPayment = "";
            }
        }

        private void Discount_Toggled(object sender, ToggledEventArgs e)
        {
            if (Discount.IsToggled)
            {
                //brand.Discount = "Discount.png";
            }
            else
            {
                //brand.Discount = "";
            }
        }

        private void AdBannerEdit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new EditAdBanner());
        }
    }
}