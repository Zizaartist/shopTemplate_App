using ApiClick.Models;
using Click.Models;
using Click.Models.LocalModels;
using Click.StaticValues;
using Click.ViewModels;
using Click.Views.User.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Orders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersReview : ContentPage
    {
        private ImageButton[] imageButtons = new ImageButton[5];
        private readonly ReviewsViewModel reviewVM;

        public OrdersReview(OrderLocal order, decimal points)
        {
            InitializeComponent();

            Points.Text = points.ToString();
            Name.Text = order.Name;
            Logo.Source = order.Logo;

            reviewVM = new ReviewsViewModel(_orderId: order.Order.OrderId);
            BindingContext = reviewVM;
            StarMassive();
        }

        void StarMassive()
        {
            imageButtons[0] = StarOne;
            imageButtons[1] = StarTwo;
            imageButtons[2] = StarThree;
            imageButtons[3] = StarFour;
            imageButtons[4] = StarFive;
        }

        private void Close_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void StarOne_Clicked(object sender, EventArgs e)
        {
            StarRating(0);
        }

        private void StarTwo_Clicked(object sender, EventArgs e)
        {
            StarRating(1);
        }

        private void StarThree_Clicked(object sender, EventArgs e)
        {
            StarRating(2);
        }

        private void StarFour_Clicked(object sender, EventArgs e)
        {
            StarRating(3);
        }

        private void StarFive_Clicked(object sender, EventArgs e)
        {
            StarRating(4);
        }

        void StarRating(int star)
        {
            for(int i=0; i<imageButtons.Length; i++)
            {
                if (i > star)
                {
                    imageButtons[i].Source = "StarWhite.png";
                }
                else
                {
                    imageButtons[i].Source = "Star.png";
                }
            }
        }

         async private void Send_Clicked(object sender, EventArgs e)
        {
            var response = await reviewVM.PostReview();

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Click", "Отзыв отправлен", "Понятно");
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Ошибка", AlertMessages.UNEXPECTED_ERROR, "Понятно");
            }
        }
    }
}