using Click.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class FlowersCategoryViewModel : BindableObject
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
        public FlowersCategoryViewModel()
        {
            FoodCategories = new ObservableCollection<FoodCategory>()
            {
                new FoodCategory()
                {
                    Image = "temp22.png",
                    Name = "Комнатные",
                },
                new FoodCategory()
                {
                    Image = "temp23.png",
                    Name = "Фруктовые",
                },
                new FoodCategory()
                {
                    Image = "temp24.png",
                    Name = "Клубничные",
                },
                new FoodCategory()
                {
                    Image = "temp25.png",
                    Name = "Тюльпаны",
                },
            };
        }
    }
}
