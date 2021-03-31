using Click.Views.AdminCompany.Orders;
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
    public partial class EnterAdminCompany : ContentPage
    {
        public EnterAdminCompany()
        {
            InitializeComponent();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void ForgotPassword_Clicked(object sender, EventArgs e)
        {

        }

        private void Enter_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new OrdersMain();
        }
    }
}