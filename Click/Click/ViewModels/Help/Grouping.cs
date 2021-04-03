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
        public string DeliveryConditions { get; set; }
        public decimal Sum { get => Items.Sum(item => item.SumPrice); }

        public Brand Brand;

        private Command selfDestructCommand;
        //public Command RefreshSum { get; private set; }

        public Grouping(K name, Brand brand, IEnumerable<T> items, Command _selfDestructCommand)
        {
            Name = name;
            Brand = brand;
            Logo = brand.ImgLogo != null ? new UriImageSource
            {
                Uri = new Uri(ApiStrings.API_HOST + ApiStrings.API_IMAGES_FOLDER + brand.ImgLogo.Path),
                CachingEnabled = true,
                CacheValidity = Caches.IMAGE_CACHE.lifeTime
            } : null;
            DeliveryConditions = brand.Rules;
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
