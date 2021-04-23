using Click.Models;
using Click.Models.LocalModels;
using Click.StaticValues;
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
    public partial class ProductCatalogue : ContentPage
    {
        public ProductCatalogue(CategoryLocal _categoryLocal)
        {
            InitializeComponent();

            var basketVM = new BasketViewModel();
            Task.Run(() => basketVM.GetData());

            //Загружаем продукцию
            var productVM = new ProductsViewModel(_categoryLocal.Category, basketVM.AddToBasket);
            BindingContext = productVM;
            Task.Run(() => productVM.GetCachedData());

            //Баллы достаточно просто сбайндить
            Points.BindingContext = UsersViewModel.Instance;

            MinimalPrice.Text = Constants.MINIMAL_PRICE.ToString(); 
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
            Navigation.PopAsync();
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

        private void Basket_Clicked_1(object sender, EventArgs e)
        {
            DisplayAlert("","Добавленно в корзину","Ок");
        }
    }
}