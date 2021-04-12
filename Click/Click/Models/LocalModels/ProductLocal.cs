using ApiClick.Models;
using Click.StaticValues;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Click.Models.LocalModels
{
    public class ProductLocal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #region properties

        public Product Product { get; set; } //required

        private Action refreshAllData;

        private int count = 0;
        public int Count
        {
            get => count;
            set
            {
                if (count == value) return;
                count = value;
                OnPropertyChanged();
                OnPropertyChanged("CountView");
                OnPropertyChanged("SumPrice");
                refreshAllData();
            }
        }

        public string CountView
        {
            get 
            {
                if (Count > 0) return Count.ToString();
                return Product.Price.ToString();
            }
        }

        public UriImageSource Image { get; private set; }

        public bool OneOrMore { get => Count > 0; }

        public decimal SumPrice { get => Count * Product.Price; }

        public Command AddCount { get; set; }

        public Command SubCount { get; set; }

        private int minCount = 0;
        private int maxCount = 99;

        #endregion

        public ProductLocal(Product _product, Action _refreshAllData)
        {
            Product = _product;

            refreshAllData = _refreshAllData;
            Image = new UriImageSource
            {
                Uri = new Uri(ApiStrings.HOST + ApiStrings.IMAGES_FOLDER + Product.Image),
                CachingEnabled = true,
                CacheValidity = Caches.IMAGE_CACHE.lifeTime
            };
            AddCount = new Command(() => 
            {
                if (Count < maxCount) Count++;
            });
            SubCount = new Command(() =>
            {
                if (Count > minCount) Count--;
            });
        }
    }
}
