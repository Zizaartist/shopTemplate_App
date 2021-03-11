using Click.ViewModels;
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
    public partial class OrdersMain : ContentPage
    {
        public OrdersMain()
        {
            InitializeComponent();
            OrderCollection.BindingContext = new OrderHistoryViewModel();
            this.BindingContext = new OrderViewModel();
        }
        private void Profile_Clicked(object sender, EventArgs e)
        {

        }

        private void Basket_Clicked(object sender, EventArgs e)
        {

        }

        private void Orders_Clicked(object sender, EventArgs e)
        {
            
        }

        private void Main_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Main());
        }
    }
}