using Click.ViewModels;
using Click.Views.AdminCompany.Editor;
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

namespace Click.Views.AdminCompany.History
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryMain : ContentPage
    {
        public HistoryMain()
        {
            InitializeComponent();
            OrderCollection.BindingContext = new OrderHistoryViewModel();
        }

        private void OrdersButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new OrdersMain();
        }

        private void HistoryButton_Clicked(object sender, EventArgs e)
        {

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