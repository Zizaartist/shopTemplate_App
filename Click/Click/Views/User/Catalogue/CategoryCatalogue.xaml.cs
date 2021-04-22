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
    public partial class CategoryCatalogue : ContentPage
    {
        public CategoryCatalogue(int? parentCategoryId = null)
        {
            InitializeComponent();

            //Загружаем меню
            var categoryVM = new CategoryViewModel(parentCategoryId);
            Refreshable.BindingContext = categoryVM;
            Task.Run(() => categoryVM.GetCachedData());

            Points.BindingContext = UsersViewModel.Instance;
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
                var category = CategoriesCollection.SelectedItem as CategoryLocal;
                CategoriesCollection.SelectedItem = null;
                if (category.Category.IsEndpoint)
                {
                    Navigation.PushModalAsync(new ProductCatalogue(category));
                }
                else
                {
                    Navigation.PushAsync(new CategoryCatalogue(category.Category.CategoryId), false);
                }
            }
        }
    }
}