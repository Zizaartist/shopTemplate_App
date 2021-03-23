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
    public partial class FoodAssortment : ContentPage
    {
        BrandInfo _brandInfo;
        public FoodAssortment(BrandInfo brandInfo)
        {
            InitializeComponent();
            HeaderGrid.BindingContext = brandInfo;
            CategoriesCollection.BindingContext = new FoodCategoryViewModel();
            _brandInfo = brandInfo;
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
                Navigation.PushModalAsync(new SubFoodAssortment(e.CurrentSelection.LastOrDefault() as FoodCategory, _brandInfo));
            }
        }

        private void About_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DescriptionOrganization(_brandInfo));
        }

        private void Reviews_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Reviews(_brandInfo));
        }
    }
}