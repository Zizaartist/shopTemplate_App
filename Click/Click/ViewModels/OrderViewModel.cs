using Click.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class OrderViewModel : BindableObject
    {
        private ObservableCollection<Order> orders;
        public ObservableCollection<Order> Orders
        {
            get => orders;
            set
            {
                if (value == orders) return;
                orders = value;
                OnPropertyChanged();
            }
        }

        public OrderViewModel()
        {
            Orders = new ObservableCollection<Order>()
            {
                new Order()
                {
                    Name = "Food Boom",
                    Logo = "temp5.png",
                    DateTime = "21 января 2021[15:25]",
                    Adress = "Адрес доставки: Курашова 22, кв. 65подъезд 2, этаж 2",
                    Price = "10407",
                },
            };
        }
    }
}
