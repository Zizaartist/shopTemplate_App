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
        static ImageButton[] imageButtons = new ImageButton[5];
        int Rating;
        public AboutApplication()
        {
            InitializeComponent();
            StarMassive();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        void StarMassive()
        {
            imageButtons[0] = StarOne;
            imageButtons[1] = StarTwo;
            imageButtons[2] = StarThree;
            imageButtons[3] = StarFour;
            imageButtons[4] = StarFive;
        }
        private void StarOne_Clicked(object sender, EventArgs e)
        {
            StarRating(0);
            Rating = 1;
        }

        private void StarTwo_Clicked(object sender, EventArgs e)
        {
            StarRating(1);
            Rating = 2;
        }

        private void StarThree_Clicked(object sender, EventArgs e)
        {
            StarRating(2);
            Rating = 3;
        }

        private void StarFour_Clicked(object sender, EventArgs e)
        {
            StarRating(3);
            Rating = 4;
        }

        private void StarFive_Clicked(object sender, EventArgs e)
        {
            StarRating(4);
            Rating = 4;
        }
        void StarRating(int star)
        {
            for (int i = 0; i < imageButtons.Length; i++)
            {
                if (i > star)
                {
                    imageButtons[i].Source = "StarGray.png";
                }
                else
                {
                    imageButtons[i].Source = "Star.png";
                }
            }
        }

        private void Close_Clicked(object sender, EventArgs e)
        {
            FrameAlert.IsVisible = false;
            Background.IsVisible = false;
            FrameReview.IsVisible = false;
        }

        private void RateApp_Clicked(object sender, EventArgs e)
        {
            FrameAlert.IsVisible = true;
            Background.IsVisible = true;
        }

        private void Rate_Clicked(object sender, EventArgs e)
        {
            FrameAlert.IsVisible = false;
            Background.IsVisible = false;
        }

        private void Review_Clicked(object sender, EventArgs e)
        {
            Background.IsVisible = true;
            FrameReview.IsVisible = true;
        }

        private void Send_Clicked(object sender, EventArgs e)
        {
            Background.IsVisible = false;
            FrameReview.IsVisible = false;
        }
    }
}