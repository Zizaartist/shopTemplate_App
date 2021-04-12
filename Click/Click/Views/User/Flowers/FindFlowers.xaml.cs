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

namespace Click.Views.User.Flowers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindFlowers : ContentPage
    {
        private static Kind Kind = Kind.flowers;

        public FindFlowers()
        {
            InitializeComponent();

            BindingContext = new BrandsViewModel(Kind, true);
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
                Navigation.PushModalAsync(new FlowersAssortment(selectedBrand));
            }
        }

        private void Find_Clicked(object sender, EventArgs e)
        {

        }
    }
}