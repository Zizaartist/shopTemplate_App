using Click.Views;
using Click.Views.AdminCompany.Editor;
using Click.Views.AdminCompany.Editor.Water;
using Click.Views.AdminCompany.Orders;
using Click.Views.Registration;
using Click.Views.User;
using Click.Views.User.Basket;
using Click.Views.User.Food;
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
        private static object syncRoot = new Object();
        private static App instance;
        public static App Instance
        {
            get
            {
                lock (syncRoot)
                {
                    return instance;
                }
            }
            set
            {
                instance = value;
            }
        }

        public Style tagGreen, tagGreenSelected, tagOrange, tagOrangeSelected, payment, paymentSelected, entryGray;
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
            entryGray = EntryGray;
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
