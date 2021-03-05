using ApiClick.Models;
using ApiClick.Models.EnumModels;
using Click.StaticValues;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Click.Models.LocalModels
{
    public class BrandLocal
    {


        public BrandLocal(Brand _brand)
        {
            Brand = _brand;
            foreach (Hashtag _tag in Brand.Hashtags)
            {
                Tags += $"{_tag.HashTagName} ";
            }
            if (Brand.PaymentMethods.Contains(PaymentMethod.cash)) CashPayment = true;
            if (Brand.PaymentMethods.Contains(PaymentMethod.card)) BankPayment = true;
            Banner = new UriImageSource
            {
                Uri = new Uri(ApiStrings.API_HOST + ApiStrings.API_IMAGES_FOLDER + Brand.ImgBanner.Path),
                CachingEnabled = true,
                CacheValidity = Caches.IMAGE_CACHE.lifeTime
            }; 
            Logo = new UriImageSource
            {
                Uri = new Uri(ApiStrings.API_HOST + ApiStrings.API_IMAGES_FOLDER + Brand.ImgLogo.Path),
                CachingEnabled = true,
                CacheValidity = Caches.IMAGE_CACHE.lifeTime
            };
            //Rating = 
        }

        public Brand Brand { get; private set; }
        public string Tags { get; private set; } = "";
        public bool BankPayment { get; private set; } = false;
        public bool CashPayment { get; private set; } = false;
        public UriImageSource Banner { get; private set; }
        public UriImageSource Logo { get; private set; }
        public float Rating { get; private set; } = 0f;
    }
}
