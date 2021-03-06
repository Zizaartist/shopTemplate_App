using Click.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class BrandInfoViewModelFlowers : BindableObject
    {
        private ObservableCollection<BrandInfo> brandInfos;
        public ObservableCollection<BrandInfo> BrandInfos
        {
            get => brandInfos;
            set
            {
                if (value == brandInfos) return;
                brandInfos = value;
                OnPropertyChanged();
            }
        }
        public BrandInfoViewModelFlowers()
        {
            BrandInfos = new ObservableCollection<BrandInfo>()
            {
                new BrandInfo()
                {
                    Name = "Цветы “Виктория”",
                    Tags = "всепраздники свадьбы",
                    Rating = "4.5",
                    BankPayment = "BankCard.png",
                    CashPayment = "Money.png",
                    Discount = "",
                    Banner = "temp19.png",
                    Logo = "temp21.png",
                    DeliveryTime = "40 мин - 1ч 40 мин",
                },
                new BrandInfo()
                {
                    Name = "Time Flowers",
                    Tags = "всепраздники розы коробки игрушки",
                    Rating = "3",
                    BankPayment = "BankCard.png",
                    CashPayment = "Money.png",
                    Discount = "",
                    Banner = "temp20.png",
                    Logo = "temp21.png",
                    DeliveryTime = "40 мин - 1ч 40 мин",
                },
            };
        }
    }
}
