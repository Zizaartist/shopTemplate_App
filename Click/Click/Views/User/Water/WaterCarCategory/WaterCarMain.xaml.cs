using ApiClick.Models;
using Click.Models;
using Click.Models.LocalModels;
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
        private static Kind KIND = Kind.water;

        public WaterCarMain()
        {
            InitializeComponent();

            //Баллы достаточно просто сбайндить
            Points.BindingContext = UsersViewModel.Instance;

            var waterVM = new WaterBrandViewModel(KIND);
            WaterCompaniesCollection.BindingContext = waterVM;
            Task.Run(() => waterVM.GetCachedData());
        }

        protected override void OnAppearing()
        {
            Task.Run(() => UsersViewModel.Instance.GetPoints());
            base.OnAppearing();
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
                var selectedWaterBrand = WaterCompaniesCollection.SelectedItem as WaterBrandLocal;
                WaterCompaniesCollection.SelectedItem = null;
                Navigation.PushModalAsync(new WaterCarForm(selectedWaterBrand));
            }
        }

        private void Confirm_Clicked(object sender, EventArgs e)
        {

        }
    }
}