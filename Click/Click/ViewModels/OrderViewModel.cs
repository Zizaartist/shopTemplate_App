using ApiClick.Models;
using ApiClick.Models.EnumModels;
using Click.Models;
using Click.Models.LocalModels;
using Click.StaticValues;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Click.ViewModels
{
    class OrderViewModel : ViewModel
    {
        #region properties

        private string name;
        public string Name 
        {
            get => name;
            set 
            {
                SetProperty(ref name, value);
                OnPropertyChanged("ValidTakeaway");
                OnPropertyChanged("ValidDelivery");
            }
        }

        //nullable
        private string commentary;
        public string Commentary 
        {
            get => commentary;
            set { SetProperty(ref commentary, value); }
        }

        private PaymentMethod paymentMethod;
        public PaymentMethod PaymentMethod 
        {
            get => paymentMethod;
            set 
            {
                SetProperty(ref paymentMethod, value);
                OnPropertyChanged("ValidTakeaway");
                OnPropertyChanged("ValidDelivery");
            }
        }

        private bool usePoints = false;
        public bool UsePoints 
        {
            get => usePoints;
            set 
            {
                SetProperty(ref usePoints, value);
                OnPropertyChanged("ValidTakeaway");
                OnPropertyChanged("ValidDelivery");
                OnPropertyChanged("TotalSum");
            }
        }

        private string street;
        public string Street 
        {
            get => street;
            set 
            {
                SetProperty(ref street, value);
                OnPropertyChanged("ValidDelivery");
            }
        }

        private string house;
        public string House 
        {
            get => house;
            set 
            {
                SetProperty(ref house, value);
                OnPropertyChanged("ValidDelivery");
            }
        }

        //nullable
        private int? entrance;
        public int? Entrance 
        {
            get => entrance;
            set 
            {
                SetProperty(ref entrance, value);
            }
        }

        //nullable
        private int? floor;
        public int? Floor 
        {
            get => floor;
            set 
            {
                SetProperty(ref floor, value);
            }
        }

        //nullable
        private int? apartment;
        public int? Apartment 
        {
            get => apartment;
            set 
            {
                SetProperty(ref apartment, value);
            }
        }

        public ICollection<PaymentMethod> AllowedPaymentMethods { get; }

        public bool ValidTakeaway 
        {
            get 
            {
                if (!string.IsNullOrEmpty(Name) &&
                    AllowedPaymentMethods.Contains(PaymentMethod)) //Не должно нарушаться 
                {
                    return true;
                }
                return false;
            }
        }

        public bool ValidDelivery 
        {
            get 
            {
                if (ValidTakeaway &&
                    !string.IsNullOrEmpty(Street) &&
                    !string.IsNullOrEmpty(House)) 
                {
                    return true;
                }
                return false;
            }
        }

        public int Percentage { get; }

        public decimal InitialSum { get; }

        public decimal Saving { get; }

        public decimal TotalSum { get => UsePoints ? InitialSum - Saving : InitialSum; }

        private List<OrderDetail> orderDetails;
        public readonly int brandId;
        private bool delivery;

        public Command ChangePaymentMethod { get; }

        #endregion

        public OrderViewModel(Help.Grouping<string, OrderDetailLocal> _orderDetails, bool _delivery)
        {
            InitialSum = _orderDetails.Sum;

            Percentage = _orderDetails.Brand.PointsPercentage;

            Saving = InitialSum * (Percentage / 100m);

            orderDetails = new List<OrderDetail>();
            _orderDetails.ForEach(detail => 
            {
                detail.OrderDetail.Product = null;
                orderDetails.Add(detail.OrderDetail);
            });
            brandId = _orderDetails.Brand.BrandId;
            delivery = _delivery;

            AllowedPaymentMethods = _orderDetails.Brand.BrandPaymentMethods.Select(bpm => bpm.PaymentMethod).ToList();
        }

        public async Task<HttpResponseMessage> PostOrder()
        {
            try
            {
                HttpClient client = await createUserClient();

                var newOrder = delivery ? ConstructDeliveryOrder() : ConstructTakeawayOrder();

                var serializedObj = SerializeIgnoreNull(newOrder);
                var data = new StringContent(serializedObj, Encoding.UTF8, "application/json");
                return await client.PostAsync(ApiStrings.HOST + ApiStrings.ORDERS_CONTROLLER, data);
            }
            catch (NoConnectionException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw CheckIfConnectionException(e);
            }
        }

        private Order ConstructDeliveryOrder() 
        {
            return new Order()
            {
                BrandId = brandId,
                PointsUsed = UsePoints,
                Delivery = true,
                OrderInfo = new OrderInfo() 
                {
                    Apartment = Apartment,
                    Commentary = Commentary,
                    Entrance = Entrance,
                    Floor = Floor,
                    House = House,
                    OrdererName = Name,
                    Street = Street
                },
                PaymentMethod = PaymentMethod,
                OrderDetails = orderDetails
            };
        }

        private Order ConstructTakeawayOrder() 
        {
            return new Order()
            {
                BrandId = brandId,
                PointsUsed = UsePoints,
                Delivery = false,
                OrderInfo = new OrderInfo()
                {
                    Commentary = Commentary,
                    OrdererName = Name
                },
                PaymentMethod = PaymentMethod,
                OrderDetails = orderDetails
            };
        }

        public void Autofill(User _userData) 
        {
            Name = _userData.UserInfo.Name;
            Street = _userData.UserInfo.Street;
            House = _userData.UserInfo.House;
            Apartment = _userData.UserInfo.Apartment;
            Entrance = _userData.UserInfo.Entrance;
            Floor = _userData.UserInfo.Floor;
        }
    }
}
