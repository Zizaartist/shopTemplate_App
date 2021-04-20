using Akavache;
using ApiClick.Models;
using Click.Models;
using Click.Models.LocalModels;
using Click.StaticValues;
using Click.ViewModels.Help;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using h = Click.ViewModels.Help;

namespace Click.ViewModels
{
    public class BasketViewModel : ViewModel
    {
        #region properties

        //brandId & product pair
        public ObservableRangeCollection<Help.Grouping<string, OrderDetailLocal>> GoodsFoodsGroups { get; } = new ObservableRangeCollection<Help.Grouping<string, OrderDetailLocal>>();

        public Command OrderDetailSelfDestruct { get; }

        public Command GroupSelfDestruct { get; }

        public Command AddToBasket { get; } 

        public Command SaveChangesCommand { get; }

        #endregion

        public BasketViewModel()
        {
            //any просто для итерации, не результата
            OrderDetailSelfDestruct = new Command(param =>
            {
                var detail = param as OrderDetailLocal;
                GoodsFoodsGroups.Any(group =>
                {
                    if (group.Contains(detail))
                    {
                        return group.Remove(detail);
                    }
                    return false;
                });
            });

            GroupSelfDestruct = new Command(param => 
            {
                var group = param as Help.Grouping<string, OrderDetailLocal>;
                GoodsFoodsGroups.Remove(group);
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
            GoodsFoodsGroups.Clear();

            //Пытаемся вытащить данные из кэша, при неудаче создаем пустую ячейку для предотвращения KeyNotFoundException
            List<OrderDetail> cachedShopcart = await new CacheFunctions().tryToGet<List<OrderDetail>>(Caches.SHOPCART_CACHE.key, CacheFunctions.BlobCaches.UserAccount);

            IEnumerable<Help.Grouping<string, OrderDetailLocal>> groupedDetails = null;

            //В случае если кэш не пуст
            if (cachedShopcart != null)
            {
                var temp = new List<OrderDetailLocal>();
                cachedShopcart.ForEach(detail => temp.Add(new OrderDetailLocal(detail, SaveChangesCommand, OrderDetailSelfDestruct)));
                groupedDetails = temp.GroupBy(p => p.Brand.BrandName)
                                            .Select(g => new Help.Grouping<string, OrderDetailLocal>(g.Last().Brand.BrandName, g.Last().Brand, g, GroupSelfDestruct));

                GoodsFoodsGroups.AddRange(groupedDetails);
            }
        }

        /// <summary>
        /// Добавляет новую деталь заказа и сохраняет изменения в кэше
        /// </summary>
        public async Task AddDetails(IEnumerable<OrderDetailLocal> newDetails)
        {
            var pileOfDetails = GoodsFoodsGroups.Any() ? GoodsFoodsGroups.SelectMany(group => group) : null;

            foreach (var detail in newDetails) 
            {
                var found = pileOfDetails?.FirstOrDefault(d => d.OrderDetail.ProductId == detail.OrderDetail.ProductId);
                if (found != null)
                {
                    found.Count += detail.Count;
                }
                else 
                {
                    var fittingGroup = GoodsFoodsGroups.FirstOrDefault(group => group.Name == detail.Brand.BrandName);
                    if (fittingGroup != null)
                    {
                        //Новая деталь
                        fittingGroup.Add(detail);
                    }
                    else 
                    {
                        //Новая группа
                        GoodsFoodsGroups.Add(new Help.Grouping<string, OrderDetailLocal>(detail.Brand.BrandName, 
                                                                                    detail.Brand, 
                                                                                    new List<OrderDetailLocal> { detail },
                                                                                    GroupSelfDestruct));
                    }
                }
            }
            await SaveChangesToCache();
        }

        /// <summary>
        /// Удаляет деталь из корзины и сохраняет изменения в кэше
        /// </summary>
        public async Task RemoveDetail(IEnumerable<OrderDetailLocal> delDetails)
        {
            var pileOfDetails = GoodsFoodsGroups.SelectMany(group => group);

            foreach (var detail in delDetails)
            {
                var found = pileOfDetails.FirstOrDefault(d => d.OrderDetail.ProductId == detail.OrderDetail.ProductId);
                if (found != null)
                {
                    found.Count--;
                }
                else
                {
                    var fittingGroup = GoodsFoodsGroups.FirstOrDefault(group => group.Name == detail.Brand.BrandName);
                    //Если группа почти пуста - удалить
                    if (fittingGroup.Count > 1)
                    {
                        fittingGroup.Remove(detail);
                    }
                    else
                    {
                        GoodsFoodsGroups.Remove(fittingGroup);
                    }
                }
            }

            await SaveChangesToCache();
        }

        /// <summary>
        /// Удаляет заказ из корзины
        /// </summary>
        public async Task RemoveOrder(int _brandId) 
        {
            var groupToRemove = GoodsFoodsGroups.First(gfg => gfg.Brand.BrandId == _brandId);
            GoodsFoodsGroups.Remove(groupToRemove);
            await SaveChangesToCache();
        }

        /// <summary>
        /// Удаляет все детали из корзины и сохраняет изменения в кэш
        /// </summary>
        public async Task Clear()
        {
            GoodsFoodsGroups.Clear();
            await SaveChangesToCache();
        }

        /// <summary>
        /// Проверяет на наличие детали
        /// </summary>
        /// <param name="_id">Id продукта</param>
        /// <returns>Деталь, содержащая продукт</returns>
        public OrderDetailLocal ContainsProduct(int _id)
        {
            foreach (OrderDetailLocal _detail in GoodsFoodsGroups.SelectMany(group => group))
            {
                if (_detail.OrderDetail.ProductId == _id) return _detail;
            }
            return null;
        }

        public async Task SaveChangesToCache()
        {
            if (IsBusy) return; //preventing parallel calls
            IsBusy = true;
            var detailList = new List<OrderDetail>();
            foreach (OrderDetailLocal detail in GoodsFoodsGroups.SelectMany(group => group))
            {
                detailList.Add(detail.OrderDetail);
            }
            await BlobCache.UserAccount.InsertObject(Caches.SHOPCART_CACHE.key, detailList);
            IsBusy = false;
        }

        #endregion
    }
}
