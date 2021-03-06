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
    public partial class FlowersAssortment : ContentPage
    {
        public FlowersAssortment()
        {
            InitializeComponent();
            CategoriesCollection.BindingContext = new FlowersCategoryViewModel();
        }

        private void Bonus_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BonusHistory());
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void CategoriesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Any())
            {
                CategoriesCollection.SelectedItem = null;
                Navigation.PushModalAsync(new SubFlowersAssortment());
            }
        }

        private void About_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DescriptionOrganizationFlowers());
        }

        private void Reviews_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ReviewsFlowers());
        }
    }
}