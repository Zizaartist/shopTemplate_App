using Click.Models.LocalModels;
using Click.ViewModels.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Basket
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasketChoice : ContentPage
    {
        private Grouping<string, OrderDetailLocal> orderDetails;

        public BasketChoice(Grouping<string, OrderDetailLocal> _orderDetails)
        {
            InitializeComponent();

            orderDetails = _orderDetails;
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        bool courier, takeaway;
        private void Takeaway_Clicked(object sender, EventArgs e)
        {
            TImage.Source = "TakeawaySelected.png";
            if (courier == false)
            {
                courier = true;
                CImage.Source = "Courier.png";
                takeaway = false;
            }
            else
            {
                Navigation.PushModalAsync(new TakeawayForm(orderDetails));
            }
        }

        private void Courier_Clicked(object sender, EventArgs e)
        {
            CImage.Source = "CourierSelected.png";
            if (takeaway == false)
            {
                takeaway = true;
                TImage.Source = "Takeaway.png";
                courier = false;
            }
            else
            {
                Navigation.PushModalAsync(new CourierForm(orderDetails));
            }
        }
    }
}