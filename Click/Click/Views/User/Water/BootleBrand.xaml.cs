using Click.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Water
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BootleBrand : ContentPage
    {
        public BootleBrand()
        {
            InitializeComponent();
            BootleCollection.BindingContext = new WaterCompanyViewModels();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Bonus_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}