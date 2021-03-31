using Click.Views.AdminCompany.Editor;
using Click.Views.AdminCompany.History;
using Click.Views.AdminCompany.Orders;
using Click.Views.AdminCompany.Reports;
using Click.Views.User;
using Click.Views.User.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.AdminCompany.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileMain : ContentPage
    {
        public ProfileMain()
        {
            InitializeComponent();
        }

        private void OrdersButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new OrdersMain();
        }

        private void HistoryButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new HistoryMain();
        }

        private void ReportsButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ReportsMain();
        }

        private void EditorButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new EditorMain();
        }

        private void ProfileButton_Clicked(object sender, EventArgs e)
        {

        }

        private void EnterUser_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Main();
        }
        private void Edit(object sender, EventArgs e)
        {

        }
        private void About(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AboutApplication());
        }
    }
}