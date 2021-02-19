using Click.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class AdBannerFoodViewModel : BindableObject
    {
        private ObservableCollection<AdBannerFood> adBannerFoods;
        public ObservableCollection<AdBannerFood> AdBannerFoods
        {
            get => adBannerFoods;
            set
            {
                if (value == adBannerFoods) return;
                adBannerFoods = value;
                OnPropertyChanged();
            }
        }
        public AdBannerFoodViewModel()
        {
            AdBannerFoods = new ObservableCollection<AdBannerFood>()
            {
                new AdBannerFood()
                {
                    Banner = "temp3.png",
                    Text = "Чизбургер в подарок!",
                },
                new AdBannerFood()
                {
                    Banner = "temp3.png",
                    Text = "Чизбургер в подарок!",
                },
            };
        }
    }
}
