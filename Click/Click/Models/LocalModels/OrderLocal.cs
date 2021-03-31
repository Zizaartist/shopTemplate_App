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
    public class OrderLocal
    {
        public OrderLocal(Order _order)
        {
            Order = _order;

            Logo = Order.BrandOwner.Brands.First().ImgLogo != null ? new UriImageSource
            {
                Uri = new Uri(ApiStrings.API_HOST + ApiStrings.API_IMAGES_FOLDER + Order.BrandOwner.Brands.First().ImgLogo.Path),
                CachingEnabled = true,
                CacheValidity = Caches.IMAGE_CACHE.lifeTime
            } : null;

            var temp = new List<string>();
            if (Order.Street != null) temp.Add(Order.Street);
            if (Order.Kv != null) temp.Add($"кв. {Order.Kv}");
            if (Order.Padik != null) temp.Add($"подъезд {Order.Padik}");
            if (Order.Etash != null) temp.Add($"этаж {Order.Etash}");
            var addressParts = temp.ToArray();
            Address = string.Join(", ", addressParts);

            Sum = Order.OrderDetails.Sum(det => det.Price * det.Count);

            Delivered = Order.OrderStatus >= OrderStatus.delivered;

            Status = OrderStatusDictionaries.GetStringFromOrderStatus[Order.OrderStatus];
        }

        public Order Order { get; private set; }
        public string Name { get; private set; }
        public UriImageSource Logo { get; private set; }
        public string Address { get; private set; }
        public decimal Sum { get; private set; }
        public bool Delivered { get; private set; }
        public string Status { get; private set; }
    }
}
