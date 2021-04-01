using Click.Views.AdminCompany.History;
using Click.Views.AdminCompany.Orders;
using Click.Views.AdminCompany.Profile;
using Click.Views.AdminCompany.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.AdminCompany.Editor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditorMain : ContentPage
    {
        public EditorMain()
        {
            InitializeComponent();
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
            
        }

        private void ProfileButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfileMain();
        }

        private void OrdersButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new OrdersMain();
        }
    }
}