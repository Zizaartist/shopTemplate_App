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
    public class WaterBrandLocal
    {
        public WaterBrandLocal(Brand _brand)
        {
            Brand = _brand;

            if (Brand.BrandPaymentMethods.Any(bpm => bpm.PaymentMethod == PaymentMethod.cash)) CashPayment = true;
            if (Brand.BrandPaymentMethods.Any(bpm => bpm.PaymentMethod == PaymentMethod.card)) BankPayment = true;

            HasCertificate = Brand.WaterBrand.Certificate != null;

            PriceWithContainer = Brand.WaterBrand.WaterPrice + Brand.WaterBrand.ContainerPrice ?? 0;

            Logo = Brand.BrandInfo.Logo != null ? new UriImageSource
            {
                Uri = new Uri(ApiStrings.HOST + ApiStrings.IMAGES_FOLDER + Brand.BrandInfo.Logo),
                CachingEnabled = true,
                CacheValidity = Caches.IMAGE_CACHE.lifeTime
            } : null;

            Certificate = Brand.WaterBrand.Certificate != null ? new UriImageSource
            {
                Uri = new Uri(ApiStrings.HOST + ApiStrings.IMAGES_FOLDER + Brand.WaterBrand.Certificate),
                CachingEnabled = true,
                CacheValidity = Caches.IMAGE_CACHE.lifeTime
            } : null;
        }

        public Brand Brand { get; private set; }
        public bool BankPayment { get; private set; } = false;
        public bool CashPayment { get; private set; } = false;
        public bool HasCertificate { get; private set; } = false;
        public decimal PriceWithContainer { get; private set; }
        public UriImageSource Logo { get; private set; }
        public UriImageSource Certificate { get; private set; }
    }
}
