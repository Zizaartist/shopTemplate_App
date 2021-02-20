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

        }

        private void Bootle_Clicked(object sender, EventArgs e)
        {

        }

        private void Vodovoz_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new WaterMenu());
        }
    }
}