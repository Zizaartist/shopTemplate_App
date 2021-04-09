using Click.Models;
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
    public partial class ReportsDay : ContentPage
    {
        public ReportsDay(Report report)
        {
            InitializeComponent();
            Wrapper.BindingContext = report;
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}