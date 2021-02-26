using Click.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels
{
    class AdBannerViewModel : ViewModel
    {
        private ObservableCollection<AdBanner> adBanners;
        public ObservableCollection<AdBanner> AdBanners { get; set; } = new ObservableCollection<AdBanner>()
        {
            new AdBanner()
            {
                Banner = "temp1.png",
                Title = "Акции до 15 февраля!",
                Description = "Бизнес-ланчи за полцены!",
            },
            new AdBanner()
            {
                Banner = "temp2.png",
                Title = "Акции до 15 февраля!",
                Description = "Бизнес-ланчи за полцены!",
            },
        };
    }
}
