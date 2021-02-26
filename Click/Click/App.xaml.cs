using Click.Views;
using Click.Views.Registration;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

[assembly: ExportFont("NeoSansPro-Regular.ttf", Alias = "NeoSansPro")]
[assembly: ExportFont("NeoSansPro-Medium.ttf", Alias = "NeoSansProBold")]
namespace Click
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Akavache.BlobCache.ApplicationName = "Click";
            Akavache.BlobCache.EnsureInitialized();

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
