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
            MainPage = new EditorMain();
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
