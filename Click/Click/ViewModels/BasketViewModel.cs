using Akavache;
using ApiClick.Models;
using Click.Models;
using Click.Models.LocalModels;
using Click.StaticValues;
using MvvmHelpers;
using ShopAdminAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Click.ViewModels
{
    public class BasketViewModel : ViewModel
    {
        #region properties

        //brandId & product pair
        public ObservableRangeCollection<OrderDetailLocal> OrderDetails { get; } = new ObservableRangeCollection<OrderDetailLocal>();

        public Command OrderDetailSelfDestruct { get; }

        public Command AddToBasket { get; } 

        public Command SaveChangesCommand { get; }

        #endregion

        public BasketViewModel()
        {
            //any просто для итерации, не результата
            OrderDetailSelfDestruct = new Command(param =>
            {
                var detail = param as OrderDetailLocal;
                OrderDetails.Remove(detail);
            });

            //Fire and forget
            SaveChangesCommand = new Command(async () => await SaveChangesToCache());

            AddToBasket = new Command(async param => 
            {
                var products = param as ObservableCollection<ProductLocal>;

                var toAdd = new List<OrderDetailLocal>();
                foreach (var product in products)
                {
                    toAdd.Add(new OrderDetailLocal(new OrderDetail()
                        {
                            Product = product.Product,
                            Count = product.Count,
                            Price = product.Product.Price,
                            ProductId = product.Product.ProductId
                        }
                    , SaveChangesCommand, OrderDetailSelfDestruct));
                }
                await AddDetails(toAdd);

                products.Clear();
            });
        }

        #region methods

        public async Task GetData()
        {
            OrderDetails.Clear();

            //Пытаемся вытащить данные из кэша, при неудаче создаем пустую ячейку для предотвращения KeyNotFoundException
            List<OrderDetail> cachedShopcart = await new CacheFunctions().tryToGet<List<OrderDetail>>(Caches.SHOPCART_CACHE.key, CacheFunctions.BlobCaches.UserAccount);

            //В случае если кэш не пуст
            if (cachedShopcart != null)
            {
                var temp = new List<OrderDetailLocal>();
                cachedShopcart.ForEach(detail => temp.Add(new OrderDetailLocal(detail, SaveChangesCommand, OrderDetailSelfDestruct)));

                OrderDetails.AddRange(temp);
            }
        }

        /// <summary>
        /// Добавляет новую деталь заказа и сохраняет изменения в кэше
        /// </summary>
        public async Task AddDetails(IEnumerable<OrderDetailLocal> newDetails)
        {
            var toAdd = new List<OrderDetailLocal>();

            foreach (var detail in newDetails) 
            {
                var found = OrderDetails?.FirstOrDefault(d => d.OrderDetail.ProductId == detail.OrderDetail.ProductId);
                if (found != null)
                {
                    found.Count += detail.Count;
                }
                else
                {
                    toAdd.Add(detail);
                }
            }

            OrderDetails.AddRange(toAdd);
            await SaveChangesToCache();
        }

        /// <summary>
        /// Удаляет деталь из корзины и сохраняет изменения в кэше
        /// </summary>
        public async Task RemoveDetail(IEnumerable<OrderDetailLocal> delDetails)
        {
            var toRemove = new List<OrderDetailLocal>();

            foreach (var detail in delDetails)
            {
                var found = OrderDetails.FirstOrDefault(d => d.OrderDetail.ProductId == detail.OrderDetail.ProductId);
                if (found != null)
                {
                    toRemove.Add(found);
                }
            }

            OrderDetails.RemoveRange(toRemove);
            await SaveChangesToCache();
        }

        /// <summary>
        /// Удаляет все детали из корзины и сохраняет изменения в кэш
        /// </summary>
        public async Task Clear()
        {
            OrderDetails.Clear();
            await SaveChangesToCache();
        }

        public async Task SaveChangesToCache()
        {
            if (IsBusy) return; //preventing parallel calls, is it though?
            IsBusy = true;
            await BlobCache.UserAccount.InsertObject(Caches.SHOPCART_CACHE.key, OrderDetails.Select(detail => detail.OrderDetail));
            IsBusy = false;
        }

        #endregion
    }
}
