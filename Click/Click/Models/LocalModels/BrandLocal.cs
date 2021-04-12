using ApiClick.Models;
using ApiClick.Models.EnumModels;
using Click.StaticValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Click.Models.LocalModels
{
    public class BrandLocal
    {
        public BrandLocal(Brand _brand)
        {
            Brand = _brand;
            foreach (BrandHashtag _tag in Brand.BrandHashtags)
            {
                Tags += $"{_tag.Hashtag?.HashTagName} ";
            }

            if (Brand.BrandPaymentMethods.Any(bpm => bpm.PaymentMethod == PaymentMethod.cash)) CashPayment = true;
            if (Brand.BrandPaymentMethods.Any(bpm => bpm.PaymentMethod == PaymentMethod.card)) BankPayment = true;

            Banner = Brand.BrandInfo.Banner != null ? new UriImageSource
            {
                Uri = new Uri(ApiStrings.HOST + ApiStrings.IMAGES_FOLDER + Brand.BrandInfo.Banner),
                CachingEnabled = true,
                CacheValidity = Caches.IMAGE_CACHE.lifeTime
            } : null; 

            Logo = Brand.BrandInfo.Logo != null ? new UriImageSource
            {
                Uri = new Uri(ApiStrings.HOST + ApiStrings.IMAGES_FOLDER + Brand.BrandInfo.Logo),
                CachingEnabled = true,
                CacheValidity = Caches.IMAGE_CACHE.lifeTime
            } : null;
        }

        public Brand Brand { get; private set; }
        public string Tags { get; private set; } = "";
        public bool BankPayment { get; private set; } = false;
        public bool CashPayment { get; private set; } = false;
        public UriImageSource Banner { get; private set; }
        public UriImageSource Logo { get; private set; }
    }
}
