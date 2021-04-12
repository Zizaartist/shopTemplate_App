using Click.Models;
using Click.ViewModels;
using Click.Views.AdminCompany.Editor;
using Click.Views.AdminCompany.History;
using Click.Views.AdminCompany.Orders;
using Click.Views.AdminCompany.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.AdminCompany.Reports
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportsMain : ContentPage
    {
        public ReportsMain()
        {
            InitializeComponent();
            ReportCollection.BindingContext = new ReportViewModel();
        }

        private void ProfileButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfileMain();
        }

        private void EditorButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new EditorMain();
        }

        private void ReportsButton_Clicked(object sender, EventArgs e)
        {

        }

        private void HistoryButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new HistoryMain();
        }

        private void OrdersButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new OrdersMain();
        }

        private void ReportCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (e.CurrentSelection.Any())
            //{
            //    ReportCollection.SelectedItem = null;
            //    Navigation.PushModalAsync(new ReportsDay(e.CurrentSelection.Last() as Report));
            //}
        }
    }
}