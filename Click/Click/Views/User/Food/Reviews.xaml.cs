﻿using Click.Models.LocalModels;
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
    public partial class Reviews : ContentPage
    {
        public Reviews(BrandLocal _brandLocal)
        {
            InitializeComponent();

            var messagesVM = new MessagesViewModel(_brandLocal.Brand.BrandId);
            BindingContext = messagesVM;
            Task.Run(() => messagesVM.GetInitialData.Execute(null));
            Task.Run(() => messagesVM.GetReviewCount());

            Points.BindingContext = UsersViewModel.Instance;

            //brand-related
            Star.BindingContext = _brandLocal;
        }

        protected override void OnAppearing()
        {
            Task.Run(() => UsersViewModel.Instance.GetPoints());
            base.OnAppearing();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Bonus_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BonusHistory());
        }

        private void ReviewsCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}