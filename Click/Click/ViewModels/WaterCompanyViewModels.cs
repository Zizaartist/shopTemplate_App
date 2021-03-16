using Click.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class WaterCompanyViewModels : BindableObject
    {
        private ObservableCollection<WaterCompany> waterCompanies;
        public ObservableCollection<WaterCompany> WaterCompanies
        {
            get => waterCompanies;
            set
            {
                if (value == waterCompanies) return;
                waterCompanies = value;
                OnPropertyChanged();
            }
        }
        public WaterCompanyViewModels()
        {
            WaterCompanies = new ObservableCollection<WaterCompany>()
            {
                new WaterCompany()
                {
                    Name = "Ледник",
                    Images = "wtemp1.png",
                    Price = "120 руб. обмен",
                    Discriptions = "",
                },
                new WaterCompany()
                {
                    Name = "Aqua Minerale",
                    Images = "wtemp2x.png",
                    Price = "100 руб. обмен",
                    Discriptions = "",
                },
                new WaterCompany()
                {
                    Name = "Elite Aqua",
                    Images = "wtemp3.png",
                    Price = "100 руб. обмен",
                    Discriptions = "",
                },
                new WaterCompany()
                {
                    Name = "Чистая Вода",
                    Images = "wtemp4.png",
                    Price = "90 руб. обмен",
                    Discriptions = "",
                },
                new WaterCompany()
                {
                    Name = "Партнер Аква",
                    Images = "wtemp5.png",
                    Price = "110 руб. обмен",
                    Discriptions = "",
                },
                new WaterCompany()
                {
                    Name = "bon aqua",
                    Images = "wtemp6.png",
                    Price = "100 руб. обмен",
                    Discriptions = "",
                },
            };
        }
    }
}
