using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutApplication : ContentPage
    {
        public AboutApplication()
        {
            InitializeComponent();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Close_Clicked(object sender, EventArgs e)
        {

        }

        private void StarOne_Clicked(object sender, EventArgs e)
        {

        }

        private void StarTwo_Clicked(object sender, EventArgs e)
        {

        }

        private void StarThree_Clicked(object sender, EventArgs e)
        {

        }

        private void StarFour_Clicked(object sender, EventArgs e)
        {

        }

        private void StarFive_Clicked(object sender, EventArgs e)
        {

        }
    }
}