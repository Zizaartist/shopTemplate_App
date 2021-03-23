using Click.Views;
using Click.Views.Registration;
using Click.Views.User.Orders;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: ExportFont("NeoSansPro-Regular.ttf", Alias = "NeoSansPro")]
[assembly: ExportFont("NeoSansPro-Medium.ttf", Alias = "NeoSansProBold")]
namespace Click
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Preview();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
