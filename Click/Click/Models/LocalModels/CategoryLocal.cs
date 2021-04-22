using ApiClick.Models;
using Click.StaticValues;
using ShopAdminAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Click.Models.LocalModels
{
    public class CategoryLocal
    {
        public CategoryLocal(Category _category) 
        {
            Category = _category;

            Image = Category.Image != null ? new UriImageSource
            {
                Uri = new Uri(ApiStrings.HOST + ApiStrings.IMAGES_FOLDER + Category.Image),
                CachingEnabled = true,
                CacheValidity = Caches.IMAGE_CACHE.lifeTime
            } : null;
        }

        public Category Category { get; private set; }
        public UriImageSource Image { get; private set; }
    }
}
