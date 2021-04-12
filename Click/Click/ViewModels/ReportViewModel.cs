using ApiClick.Models;
using Click.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class ReportViewModel : BindableObject
    {
        private ObservableCollection<Report> reports;
        public ObservableCollection<Report> Reports
        {
            get => reports;
            set
            {
                if (value == reports) return;
                reports = value;
                OnPropertyChanged();
            }
        }

        public ReportViewModel()
        {
            Reports = new ObservableCollection<Report>()
            {
                //new Report()
                //{
                //    GoodsOfDayName = "Биг Кинг ХХХ",
                //    GoodsOfDayImage = "temp15.png",
                //    GoodsOfDayOrders = "8",
                //    GoodsOfDaySum = "16000",
                //    OrdersOnDay = "49",
                //    SumOnDay = "56381",
                //    Date = "20 января",
                //    WeekDay = "Понедельник",
                //    OwnerName = "Burger King",
                //    OwnerImage = "temp5.png",
                //},
                //new Report()
                //{
                //    GoodsOfDayName = "Биг Кинг ХХХ",
                //    GoodsOfDayImage = "temp15.png",
                //    GoodsOfDayOrders = "8",
                //    GoodsOfDaySum = "16000",
                //    OrdersOnDay = "59",
                //    SumOnDay = "56381",
                //    Date = "21 января",
                //    WeekDay = "Вторник",
                //    OwnerName = "Burger King",
                //    OwnerImage = "temp5.png",
                //},
                //new Report()
                //{
                //    GoodsOfDayName = "Биг Кинг ХХХ",
                //    GoodsOfDayImage = "temp15.png",
                //    GoodsOfDayOrders = "8",
                //    GoodsOfDaySum = "16000",
                //    OrdersOnDay = "32",
                //    SumOnDay = "56381",
                //    Date = "22 января",
                //    WeekDay = "Среда",
                //    OwnerName = "Burger King",
                //    OwnerImage = "temp5.png",
                //},
                //new Report()
                //{
                //    GoodsOfDayName = "Биг Кинг ХХХ",
                //    GoodsOfDayImage = "temp15.png",
                //    GoodsOfDayOrders = "8",
                //    GoodsOfDaySum = "16000",
                //    OrdersOnDay = "54",
                //    SumOnDay = "56381",
                //    Date = "23 января",
                //    WeekDay = "Четверг",
                //    OwnerName = "Burger King",
                //    OwnerImage = "temp5.png",
                //},
                //new Report()
                //{
                //    GoodsOfDayName = "Биг Кинг ХХХ",
                //    GoodsOfDayImage = "temp15.png",
                //    GoodsOfDayOrders = "8",
                //    GoodsOfDaySum = "16000",
                //    OrdersOnDay = "44",
                //    SumOnDay = "56381",
                //    Date = "24 января",
                //    WeekDay = "Пятница",
                //    OwnerName = "Burger King",
                //    OwnerImage = "temp5.png",
                //},
            };
        }
    }
}
