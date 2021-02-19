using Click.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class BrandInfoViewModel : BindableObject
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
        public BrandInfoViewModel()
        {
            BrandInfos = new ObservableCollection<BrandInfo>()
            {
                new BrandInfo()
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
                },
                new BrandInfo()
                {
                    Name = "Food Boom",
                    Tags = "пицца японская азиатская",
                    Rating = "4.5",
                    BankPayment = "BankCard.png",
                    CashPayment = "Money.png",
                    Discount = "Discount.png",
                    Banner = "temp6.png",
                    Logo = "temp7.png",
                    DeliveryTime = "40 мин - 1ч 40 мин",
                },
            };
        }
    }
}
