using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Click.Models
{
    public partial class BrandInfo
    {
        public string Name { get; set; }
        public string Tags { get; set; }
        public string Rating { get; set; }
        public string BankPayment { get; set; }
        public string CashPayment { get; set; }
        public string Discount { get; set; }
        public string Banner { get; set; }
        public string Logo { get; set; }
        public string DeliveryTime { get; set; }
        public string Contacts { get; set; }
        public string MinPrice { get; set; }
        public string ConditionDelivery { get; set; }
    }
}
