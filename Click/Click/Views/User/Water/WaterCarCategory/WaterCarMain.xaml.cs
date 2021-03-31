using Click.Models;
using Click.ViewModels;
using Click.Views.User.Water.BootleCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Water.WaterCarCategory
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WaterCarMain : ContentPage
    {
        public WaterCarMain()
        {
            InitializeComponent();
            WaterCompaniesCollection.BindingContext = new WaterCompanyViewModels();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Bonus_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BonusHistory());
        }
        private void Express_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new WaterCarFormExpress());
        }
        private void WaterCompaniesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Any())
            {
                WaterCompaniesCollection.SelectedItem = null;
                Navigation.PushModalAsync(new WaterCarForm());
            }
        }

        private void Confirm_Clicked(object sender, EventArgs e)
        {

        }
    }
}