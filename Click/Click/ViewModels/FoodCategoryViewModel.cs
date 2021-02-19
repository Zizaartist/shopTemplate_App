using Click.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class FoodCategoryViewModel : BindableObject
    {
        private ObservableCollection<FoodCategory> foodCategories;
        public ObservableCollection<FoodCategory> FoodCategories
        {
            get => foodCategories;
            set
            {
                if (value == foodCategories) return;
                foodCategories = value;
                OnPropertyChanged();
            }
        }
        public FoodCategoryViewModel()
        {
            FoodCategories = new ObservableCollection<FoodCategory>()
            {
                new FoodCategory()
                {
                    Image = "temp8.png",
                    Name = "Бургеры с говядиной",
                },
                new FoodCategory()
                {
                    Image = "temp9.png",
                    Name = "Картошка фри",
                },
                new FoodCategory()
                {
                    Image = "temp10.png",
                    Name = "Наборы",
                },
                new FoodCategory()
                {
                    Image = "temp11.png",
                    Name = "Напитки",
                },
                new FoodCategory()
                {
                    Image = "temp12.png",
                    Name = "Роллы",
                },
                new FoodCategory()
                {
                    Image = "temp13.png",
                    Name = "Сэндвичи",
                },
            };
        }
    }
}
