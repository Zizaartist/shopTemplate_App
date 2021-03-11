using ApiClick.Models;
using Click.Models.LocalModels;
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
    public partial class FindFood : ContentPage
    {
        private static Category CATEGORY = Category.food;

        public FindFood()
        {
            InitializeComponent();

            BindingContext = new BrandsViewModel(CATEGORY, true);
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void OrganisationCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Any())
            {
                var selectedBrand = OrganisationCollection.SelectedItem as BrandLocal;
                OrganisationCollection.SelectedItem = null;
                Navigation.PushModalAsync(new FoodAssortment(selectedBrand));
            }
        }
    }
}