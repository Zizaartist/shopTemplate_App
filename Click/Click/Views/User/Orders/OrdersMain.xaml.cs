﻿using ApiClick.Models;
using Click.Models;
using Click.Models.LocalModels;
using Click.StaticValues;
using Click.ViewModels;
using Click.Views.User.Basket;
using Click.Views.User.Food;
using Click.Views.User.Profile;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Click.Views.User.Orders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersMain : ContentPage
    {
        private readonly OrderHistoryViewModel ordersVM;

        public OrdersMain()
        {
            InitializeComponent();

            ordersVM = new OrderHistoryViewModel();
            BindingContext = ordersVM;
            Task.Run(() => ordersVM.GetCachedData());
        }
        private void ProfileButton_Clicked(object sender, EventArgs e)
        {
            Navigation.teleportTo(new ProfileMain());
        }

        private void BasketButton_Clicked(object sender, EventArgs e)
        {
            Navigation.teleportTo(new BasketMain());
        }

        private void OrdersButton_Clicked(object sender, EventArgs e)
        {

        }

        private void MainButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync(false);
        }

        private async void OrderCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Any())
            {
                OrderCollection.SelectedItem = null;
                if ((e.CurrentSelection.LastOrDefault() as OrderLocal).Delivered == true)
                {
                    var selection = e.CurrentSelection.LastOrDefault() as OrderLocal;
                    var response = await ordersVM.ClaimPoints(selection.Order.OrderId);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        decimal points = JsonConvert.DeserializeObject<decimal>(result);

                        //провоцируем перезапись кэша, fire&forget
                        await ordersVM.GetInitial();
                        await DisplayAlert("Click", $"Получено {points} баллов", "Ok");
                    }
                    else 
                    {
                        await DisplayAlert("Ошибка", AlertMessages.ERROR_CAN_NOT_CLAIM_POINTS, "Ok");
                    }
                }
            }
        }
    }
}