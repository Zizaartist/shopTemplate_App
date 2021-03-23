using Click.Models;
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
        public FindFood()
        {
            InitializeComponent();
            OrganisationCollection.BindingContext = new BrandInfoViewModel();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void OrganisationCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Any())
            {
                OrganisationCollection.SelectedItem = null;
                Navigation.PushModalAsync(new FoodAssortment(e.CurrentSelection.LastOrDefault() as BrandInfo));
            }
        }

        private void Find_Clicked(object sender, EventArgs e)
        {

        }
    }
}