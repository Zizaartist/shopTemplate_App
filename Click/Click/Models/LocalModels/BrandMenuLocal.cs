using ApiClick.Models;
using Click.StaticValues;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Click.Models.LocalModels
{
    public class BrandMenuLocal
    {
        public BrandMenuLocal(BrandMenu _brandMenu) 
        {
            BrandMenu = _brandMenu;
            Image = new UriImageSource
            {
                Uri = new Uri(ApiStrings.API_HOST + ApiStrings.API_IMAGES_FOLDER + BrandMenu.Image.Path),
                CachingEnabled = true,
                CacheValidity = Caches.IMAGE_CACHE.lifeTime
            };
        }

        public BrandMenu BrandMenu { get; private set; }
        public UriImageSource Image { get; private set; }
    }
}
