using ApiClick.Models;
using Click.Models.LocalModels;
using Click.StaticValues;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Click.ViewModels.Help
{
    public class Grouping<K, T> : ObservableCollection<T>, INotifyPropertyChanged where T : OrderDetailLocal
    {
        public K Name { get; private set; }
        public UriImageSource Logo { get; set; }
        public string DeliveryTerms { get; set; }
        public decimal Sum { get => Items.Sum(item => item.SumPrice); }
        public bool HasDeliveryTerms { get; private set; } = false;

        public Brand Brand;

        private Command selfDestructCommand;
        //public Command RefreshSum { get; private set; }

        public Grouping(K name, Brand brand, IEnumerable<T> items, Command _selfDestructCommand)
        {
            Name = name;
            Brand = brand;
            Logo = brand.BrandInfo.Logo != null ? new UriImageSource
            {
                Uri = new Uri(ApiStrings.HOST + ApiStrings.IMAGES_FOLDER + brand.BrandInfo.Logo),
                CachingEnabled = true,
                CacheValidity = Caches.IMAGE_CACHE.lifeTime
            } : null;
            DeliveryTerms = brand.BrandInfo.DeliveryTerms;
            HasDeliveryTerms = !string.IsNullOrEmpty(brand.BrandInfo.DeliveryTerms);
            selfDestructCommand = _selfDestructCommand;

            //RefreshSum = new Command(() => );

            foreach (T item in items) 
            {
                //item.InjectSumCommand(RefreshSum);
                Items.Add(item);
            }

            CollectionChanged += (sender, e) => 
            {
                if (Count <= 0) selfDestructCommand.Execute(this);
            };
        }
    }
}
