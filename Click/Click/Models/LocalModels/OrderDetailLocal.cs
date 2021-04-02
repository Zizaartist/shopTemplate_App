using ApiClick.Models;
using Click.StaticValues;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Click.Models.LocalModels
{
    public class OrderDetailLocal : ObservableObject
    {
        public OrderDetailLocal(OrderDetail _orderDetail, Command _saveChanges, Command _selfDestructCommand)
        {
            OrderDetail = _orderDetail;
            selfDestructCommand = _selfDestructCommand;
            saveChanges = _saveChanges;

            Logo = OrderDetail.Product.Image != null ? new UriImageSource
            {
                Uri = new Uri(ApiStrings.API_HOST + ApiStrings.API_IMAGES_FOLDER + OrderDetail.Product.Image.Path),
                CachingEnabled = true,
                CacheValidity = Caches.IMAGE_CACHE.lifeTime
            } : null;
            AddCount = new Command(() =>
            {
                if (Count < maxCount) 
                {
                    Count++;
                    saveChanges.Execute(null);
                } 
            });
            SubCount = new Command(() =>
            {
                Count--;
                saveChanges.Execute(null);
            });
        }

        public void InjectSumCommand(Command _updateSum) => updateSum = _updateSum;

        private Command saveChanges;
        private Command selfDestructCommand;
        private Command updateSum;
        public Command AddCount { get; private set; }
        public Command SubCount { get; private set; }

        private int maxCount = 99;

        public OrderDetail OrderDetail { get; set; }
        public UriImageSource Logo { get; private set; }
        public Brand Brand { get => OrderDetail.Product.BrandMenu.Brand; }
        public decimal SumPrice { get => OrderDetail.Price * OrderDetail.Count; }
        public int Count 
        {
            get => OrderDetail.Count;
            set 
            {
                if (Count == value) return;
                if (value <= 0)
                {
                    selfDestructCommand.Execute(this);
                }
                else
                {
                    OrderDetail.Count = value;
                    OnPropertyChanged();
                    OnPropertyChanged("SumPrice");
                    updateSum?.Execute(null);
                }
            }
        }
    }
}
