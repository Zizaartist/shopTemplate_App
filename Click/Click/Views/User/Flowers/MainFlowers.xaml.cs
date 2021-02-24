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
    public partial class MainFlowers : ContentPage
    {
        public MainFlowers()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            AdFoodCollection.BindingContext = new AdBannerFlowersViewModel();
            TagCollection.BindingContext = new TagFlowersViewModel();
            OrganisationCollection.BindingContext = new BrandInfoViewModelFlowers();
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
                Navigation.PushModalAsync(new FlowersAssortment());
            }
        }
    }
}