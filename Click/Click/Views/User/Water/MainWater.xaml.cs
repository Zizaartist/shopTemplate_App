using Click.Views.User.Water.BootleCategory;
using Click.Views.User.Water.WaterCarCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Water
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainWater : ContentPage
    {
        public MainWater()
        {
            InitializeComponent();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Bonus_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BonusHistory());
        }
        bool bootle, vodovoz;
        private void Bootle_Clicked(object sender, EventArgs e)
        {
            BootleImage.Source = "BootleSelected.png";
            if (bootle == false)
            {
                bootle = true;
                WaterCarImage.Source = "WaterCar.png";
                vodovoz = false;
            }
            else
            {
                Navigation.PushModalAsync(new BootleMain());
            }
        }

        private void Vodovoz_Clicked(object sender, EventArgs e)
        {
            WaterCarImage.Source = "WaterCarSelected.png";
            if (vodovoz == false)
            {
                vodovoz = true;
                BootleImage.Source = "Bootle.png";
                bootle = false;
            }
            else
            {
                Navigation.PushModalAsync(new WaterCarMain());
            }
        }
    }
}