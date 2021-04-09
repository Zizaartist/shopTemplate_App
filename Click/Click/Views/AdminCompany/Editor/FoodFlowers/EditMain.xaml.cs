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
        BrandInfo brandInfo = new BrandInfo();
        public EditMain()
        {
            InitializeComponent();
            brandinfo();
            string type = "food";
            stylesset(type);
            BindingContext = brandInfo;
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
            brandInfo = new BrandInfo()
            {
                Name = "Burger King",
                Tags = "бургеры фастфуд",
                Rating = "4.5",
                BankPayment = "BankCard.png",
                CashPayment = "Money.png",
                Discount = "Discount.png",
                Banner = "temp4.png",
                Logo = "temp5.png",
                DeliveryTime = "40 мин - 1ч 40 мин",
            };
        }

        async private void NameEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите название организации");
            brandInfo.Name = result;
        }

        async private void DescriptionEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите описание организации");
            brandInfo.Name = result;
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
            brandInfo.ConditionDelivery = result;
        }

        async private void ContactsEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите контакты организации");
            brandInfo.Contacts = result;
        }

        async private void MinPriceEntry_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Click", "Введите мин. стоимость заказа");
            brandInfo.MinPrice = result;
        }

        private void CashPayment_Toggled(object sender, ToggledEventArgs e)
        {
            if (CashPayment.IsToggled)
            {
                brandInfo.CashPayment = "Money.png";
            }
            else
            {
                brandInfo.CashPayment = "";
            }
        }

        private void CardPayment_Toggled(object sender, ToggledEventArgs e)
        {
            if (CardPayment.IsToggled)
            {
                brandInfo.BankPayment = "BankCard.png";
            }
            else
            {
                brandInfo.BankPayment = "";
            }
        }

        private void Discount_Toggled(object sender, ToggledEventArgs e)
        {
            if (Discount.IsToggled)
            {
                brandInfo.Discount = "Discount.png";
            }
            else
            {
                brandInfo.Discount = "";
            }
        }

        private void AdBannerEdit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new EditAdBanner());
        }
    }
}