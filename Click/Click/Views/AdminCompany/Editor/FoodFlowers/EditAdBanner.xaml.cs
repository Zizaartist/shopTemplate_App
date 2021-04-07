using Click.Models;
using Click.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.AdminCompany.Editor.FoodFlowers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAdBanner : ContentPage
    {
        public EditAdBanner()
        {
            InitializeComponent();
            AdFoodCollection.BindingContext = new AdBannerFoodViewModel();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void AddBanner_Clicked(object sender, EventArgs e)
        {
            AdBannerFood blank = new AdBannerFood();
            Navigation.PushModalAsync(new EditAdBannerAdd(blank));
        }

        private void AdFoodCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Any())
            {
                AdFoodCollection.SelectedItem = null;
                Navigation.PushModalAsync(new EditAdBannerAdd(e.CurrentSelection.Last() as AdBannerFood));
            }
        }
    }
}