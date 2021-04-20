﻿using ApiClick.Models;
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
    public partial class FoodAssortment : ContentPage
    {
        BrandLocal brandLocal;

        public FoodAssortment(BrandLocal _brandLocal)
        {
            InitializeComponent();

            brandLocal = _brandLocal;

            //Загружаем меню
            var categoryVM = new CategoryViewModel(_brandLocal.Brand);
            Refreshable.BindingContext = categoryVM;
            Task.Run(() => categoryVM.GetCachedData());

            ReviewCount.Text = _brandLocal.Brand.ReviewCount.ToString();

            Points.BindingContext = UsersViewModel.Instance;

            //brand-related
            BrandName.Text = _brandLocal.Brand.BrandName;
            BrandLogo.Source = _brandLocal.Logo;
            BrandBanner.Source = _brandLocal.Banner;
            Star.BindingContext = _brandLocal;
        }

        protected override void OnAppearing()
        {
            Task.Run(() => UsersViewModel.Instance.GetPoints());
            base.OnAppearing();
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
                Navigation.PushModalAsync(new SubFoodAssortment(category));
            }
        }

        private void About_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DescriptionOrganization(brandLocal.Brand.BrandId));
        }

        private void Messages_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Messages(brandLocal));
        }
    }
}