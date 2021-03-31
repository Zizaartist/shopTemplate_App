using Click.Views;
using Click.Views.Registration;
using Click.Views.User;
using Click.Views.User.Basket;
using Click.Views.User.Food;
using Click.Views.User.Orders;
using Click.Views.User.Water;
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
        public Style tagGreen, tagGreenSelected, tagOrange, tagOrangeSelected, payment, paymentSelected;
        public App()
        {
            InitializeComponent();
            InitializationPublicStyles();

            Akavache.BlobCache.ApplicationName = "Click";
            Akavache.BlobCache.EnsureInitialized();

            MainPage = new Preview();
        }

        void InitializationPublicStyles()
        {
            tagGreen = TagButtonGreen;
            tagGreenSelected = TagButtonGreenSelected;
            tagOrange = TagButtonOrange;
            tagOrangeSelected = TagButtonOrangeSelected;
            payment = Payment;
            paymentSelected = PaymentSelected;
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
