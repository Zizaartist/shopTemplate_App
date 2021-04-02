﻿using Click.Models;
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

namespace Click.Views.User.Flowers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubFlowersAssortment : ContentPage
    {
        public SubFlowersAssortment(BrandMenuLocal _brandMenuLocal)
        {
            InitializeComponent();

            var basketVM = new BasketViewModel();
            Task.Run(() => basketVM.GetData());

            //Загружаем продукцию
            var productVM = new ProductListViewModel(_brandMenuLocal.BrandMenu, basketVM.AddToBasket);
            BindingContext = productVM;
            Task.Run(() => productVM.GetCachedData());

            //Баллы достаточно просто сбайндить
            Points.BindingContext = UsersViewModel.Instance;

            //brandMenu-related
            MinimalPrice.Text = (_brandMenuLocal.BrandMenu.Brand.MinimalPrice ?? default).ToString();
            NameLabel.Text = _brandMenuLocal.BrandMenu.Brand.BrandName;
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