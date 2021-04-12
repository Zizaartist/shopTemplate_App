using Click.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.AdminCompany.Orders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutOrder : ContentPage
    {
        public AboutOrder()
        {
            InitializeComponent();
            OrderCollection.BindingContext = new BasketViewModel();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}