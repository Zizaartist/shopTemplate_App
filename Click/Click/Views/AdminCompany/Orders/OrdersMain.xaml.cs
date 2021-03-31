using Click.Views.AdminCompany.Editor;
using Click.Views.AdminCompany.History;
using Click.Views.AdminCompany.Profile;
using Click.Views.AdminCompany.Reports;
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
    public partial class OrdersMain : ContentPage
    {
        public OrdersMain()
        {
            InitializeComponent();
        }

        private void OrdersButton_Clicked(object sender, EventArgs e)
        {

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
            App.Current.MainPage = new ProfileMain();
        }
    }
}