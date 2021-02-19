using Click.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class TagFoodViewModel : BindableObject
    {
        private ObservableCollection<TagFood> tagFoods;
        public ObservableCollection<TagFood> TagFoods
        {
            get => tagFoods;
            set
            {
                if (value == tagFoods) return;
                tagFoods = value;
                OnPropertyChanged();
            }
        }
        public TagFoodViewModel()
        {
            TagFoods = new ObservableCollection<TagFood>()
            {
                new TagFood()
                {
                    Tag = "Все",
                },
                new TagFood()
                {
                    Tag = "#Восточная",
                },
                new TagFood()
                {
                    Tag = "#Бизнес ланч",
                },
                new TagFood()
                {
                    Tag = "#Пицца",
                },
            };
        }
    }
}
