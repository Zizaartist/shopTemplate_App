using Click.Models;
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
        BrandInfo _brandInfo;
        public FlowersAssortment(BrandInfo brandInfo)
        {
            InitializeComponent();
            CategoriesCollection.BindingContext = new FlowersCategoryViewModel();
            _brandInfo = brandInfo;
            WrapperGrid.BindingContext = brandInfo;
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
                Navigation.PushModalAsync(new SubFlowersAssortment(e.CurrentSelection.LastOrDefault() as FoodCategory, _brandInfo));
            }
        }

        private void About_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DescriptionOrganizationFlowers(_brandInfo));
        }

        private void Reviews_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ReviewsFlowers(_brandInfo));
        }
    }
}