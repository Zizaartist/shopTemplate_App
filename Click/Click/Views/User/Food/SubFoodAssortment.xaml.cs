using Click.Models;
using Click.Models.LocalModels;
using Click.ViewModels;
using Click.Views.User.Basket;
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
        public SubFoodAssortment(CategoryLocal _categoryLocal)
        {
            InitializeComponent();

            //Загружаем продукцию
            var productVM = new ProductsViewModel(_categoryLocal.Category);
            BindingContext = productVM;
            Task.Run(() => productVM.GetCachedData());

            //Баллы достаточно просто сбайндить
            Points.BindingContext = UsersViewModel.Instance;

            //category-related
            MinimalPrice.Text = _categoryLocal.Category.Brand.MinimalPrice.ToString();
            BrandName.Text = _categoryLocal.Category.Brand.BrandName;
        }

        protected override void OnAppearing()
        {
            Task.Run(() => UsersViewModel.Instance.GetPoints());
            base.OnAppearing();
        }

        private void FoodCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Any())
            {
                AboutProductGrid.IsVisible = true;
            }
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Bonus_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BonusHistory());
        }

        private void Basket_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new BasketMain();
        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            AboutProductGrid.IsVisible = false;
        }
    }
}