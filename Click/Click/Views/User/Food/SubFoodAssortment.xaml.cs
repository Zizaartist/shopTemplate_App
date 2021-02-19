using Click.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Food
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubFoodAssortment : ContentPage
    {
        public SubFoodAssortment()
        {
            InitializeComponent();
            FoodCollection.BindingContext = new GoodsFoodViewModel();
        }

        private void FoodCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Any())
            {
                FoodCollection.SelectedItem = null;
                AboutProductGrid.IsVisible = true;
            }
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Bonus_Clicked(object sender, EventArgs e)
        {

        }

        private void Basket_Clicked(object sender, EventArgs e)
        {

        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            AboutProductGrid.IsVisible = false;
        }
    }
}