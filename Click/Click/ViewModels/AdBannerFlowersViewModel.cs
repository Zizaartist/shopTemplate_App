using Click.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class AdBannerFlowersViewModel : BindableObject
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
        public AdBannerFlowersViewModel()
        {
            AdBannerFoods = new ObservableCollection<AdBannerFood>()
            {
                new AdBannerFood()
                {
                    Banner = "temp18.png",
                    Text = "2 букета по цене 1!",
                },
                new AdBannerFood()
                {
                    Banner = "temp18.png",
                    Text = "2 букета по цене 1!",
                },
            };
        }
    }
}
