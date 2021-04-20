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
    class WaterOrderViewModel : ViewModel
    {
        #region properties

        private string name;
        public string Name 
        {
            get => name;
            set 
            {
                SetProperty(ref name, value);
                OnPropertyChanged("ValidNormal");
                OnPropertyChanged("ValidExpress");
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
                OnPropertyChanged("ValidNormal");
            }
        }

        private string street;
        public string Street 
        {
            get => street;
            set 
            {
                SetProperty(ref street, value);
                OnPropertyChanged("ValidNormal");
                OnPropertyChanged("ValidExpress");
            }
        }

        private string house;
        public string House 
        {
            get => house;
            set 
            {
                SetProperty(ref house, value);
                OnPropertyChanged("ValidNormal");
                OnPropertyChanged("ValidExpress");
            }
        }

        private int? amount = null;
        public string Amount
        {
            get => amount.ToString();
            set 
            {
                int.TryParse(value, out int res);
                int? nullableRes = null;
                if (res != default) nullableRes = res;
                SetProperty(ref amount, nullableRes);
                OnPropertyChanged("ValidNormal");
                OnPropertyChanged("ValidExpress");
            }
        }

        private string phone;
        public string Phone 
        {
            get => phone;
            set { SetProperty(ref phone, value); }
        }

        private bool? container = null;
        public bool Container 
        {
            get => container ?? false;
            set { SetProperty(ref container, value); }
        }

        private DateTime? deliveryDateTime;
        public DateTime? DeliveryDateTime 
        {
            get => deliveryDateTime;
            set 
            {
                SetProperty(ref deliveryDateTime, value);
                OnPropertyChanged("ValidNormal");
                OnPropertyChanged("DeliveryDateTimeString");
            }
        }

        //nullable
        private int? entrance;
        public int? Entrance 
        {
            get => entrance;
            set { SetProperty(ref entrance, value); }
        }

        //nullable
        private int? floor;
        public int? Floor 
        {
            get => floor;
            set { SetProperty(ref floor, value); }
        }

        //nullable
        private int? apartment;
        public int? Apartment 
        {
            get => apartment;
            set { SetProperty(ref apartment, value); }
        }

        public ICollection<PaymentMethod> AllowedPaymentMethods { get; }

        public bool ValidNormal
        {
            get 
            {
                if (ValidExpress &&
                    (DeliveryDateTime > AcceptableDateTime || DeliveryDateTime == null) &&
                    AllowedPaymentMethods.Contains(PaymentMethod)) //Не должно нарушаться 
                {
                    return true;
                }
                return false;
            }
        }

        public bool ValidExpress 
        {
            get 
            {
                if (!string.IsNullOrEmpty(Street) &&
                    !string.IsNullOrEmpty(House) &&
                    !string.IsNullOrEmpty(Name) &&
                    (amount > 0 && amount != null)) 
                {
                    return true;
                }
                return false;
            }
        }

        private DateTime AcceptableDateTime { get => DateTime.Now.AddMinutes(30); }

        public readonly int? brandId;
        public WaterBrandLocal BrandData { get; }
        private bool express;
        private Kind kind;

        public Command ChangePaymentMethod { get; }

        #endregion

        public WaterOrderViewModel(bool _express, Kind _kind, WaterBrandLocal _brandData = null)
        {
            brandId = _brandData?.Brand.BrandId;
            BrandData = _brandData;
            express = _express;
            kind = _kind;
            if (_kind == Kind.bottledWater) Container = false;

            //Если express, то дозволены все методы оплаты
            AllowedPaymentMethods = _brandData?.Brand.BrandPaymentMethods.Select(bpm => bpm.PaymentMethod).ToList() ?? 
                                            new List<PaymentMethod>() { PaymentMethod.cash, PaymentMethod.card, PaymentMethod.online };
        }

        public async Task<HttpResponseMessage> PostOrder()
        {
            try
            {
                HttpClient client = await createUserClient();

                var newOrder = new Order()
                {
                    BrandId = brandId,
                    PaymentMethod = PaymentMethod,
                    Kind = kind,
                    OrderInfo = new OrderInfo()
                    {
                        Apartment = Apartment,
                        Commentary = Commentary,
                        Entrance = Entrance,
                        Floor = Floor,
                        House = House,
                        Street = Street,
                        Phone = Phone,
                        OrdererName = Name
                    },
                    WaterOrder = new WaterOrder()
                    {
                        Amount = amount ?? default,
                        DeliveryDate = DeliveryDateTime,
                        Express = express,
                        Container = container
                    }
                };

                var serializedObj = SerializeIgnoreNull(newOrder);
                var data = new StringContent(serializedObj, Encoding.UTF8, "application/json");
                return await client.PostAsync(ApiStrings.HOST + ApiStrings.ORDERS_POST_WATER, data);
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
