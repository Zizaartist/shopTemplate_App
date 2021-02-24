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
    public partial class MainFood : ContentPage
    {
        public MainFood()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            AdFoodCollection.BindingContext = new AdBannerFoodViewModel();
            TagCollection.BindingContext = new TagFoodViewModel();
            OrganisationCollection.BindingContext = new BrandInfoViewModel();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Bonus_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BonusHistory());
        }

        private void Find_Clicked(object sender, EventArgs e)
        {

        }

        private void OrganisationCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Any())
            {
                OrganisationCollection.SelectedItem = null;
                Navigation.PushModalAsync(new FoodAssortment());
            }
        }
    }
}