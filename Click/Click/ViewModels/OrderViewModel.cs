using ApiClick.Models;
using ApiClick.Models.EnumModels;
using Click.Models;
using Click.Models.LocalModels;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Click.ViewModels
{
    class OrderViewModel : BaseViewModel
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

        public Command ChangePaymentMethod { get; }

        #endregion

        public OrderViewModel(Help.Grouping<string, OrderDetailLocal> _orderDetails)
        {
            InitialSum = _orderDetails.Sum;

            Percentage = _orderDetails.Brand.PointsPercentage;

            Saving = InitialSum * (Percentage / 100m);

            orderDetails = new List<OrderDetail>();
            _orderDetails.ForEach(detail => orderDetails.Add(detail.OrderDetail));

            AllowedPaymentMethods = _orderDetails.Brand.PaymentMethods;
        }

        public void Autofill(User _userData) 
        {
            Name = _userData.Name;
            Street = _userData.Street;
            House = _userData.House;
            Apartment = _userData.Kv;
            Entrance = _userData.Padik;
            Floor = _userData.Etash;
        }
    }
}
