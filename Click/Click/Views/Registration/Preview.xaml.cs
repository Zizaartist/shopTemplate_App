using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.Registration
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Preview : ContentPage
    {
        public Preview()
        {
            InitializeComponent();
            NewPage();
        }
        async void NewPage()
        {
            logo.Opacity = 0;
            await logo.FadeTo(1, 3000);
            App.Current.MainPage = new NavigationPage(new Number());
        }
    }
}