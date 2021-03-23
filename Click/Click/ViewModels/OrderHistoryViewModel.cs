using Click.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class OrderHistoryViewModel : BindableObject
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
        public OrderHistoryViewModel()
        {
            Orders = new ObservableCollection<Order>()
            {
                new Order()
                {
                    Name = "Food Boom",
                    Logo = "temp7.png",
                    DateTime = "21 января 2021[15:25]",
                    Adress = "Курашова 22, Частный дом",
                    Price = "1000",
                    Delivered = true,
                },
                new Order()
                {
                    Name = "Burger king",
                    Logo = "temp5.png",
                    DateTime = "21 января 2021[15:25]",
                    Adress = "Курашова 22, Частный дом",
                    Price = "2400",
                    Delivered = false,
                },
                new Order()
                {
                    Name = "Цветы “Виктория”",
                    Logo = "temp21.png",
                    DateTime = "21 января 2021[15:25]",
                    Adress = "Курашова 22, Частный дом",
                    Price = "3000",
                    Delivered = true,
                },
                new Order()
                {
                    Name = "",
                },
            };
            Orders = new ObservableCollection<Order>(Orders.OrderBy(i=>i.Delivered));
        }
    }
}
