using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Click.ViewModels;
using Click.Models;
using ApiClick.Models;
using Click.Models.LocalModels;
using ApiClick.Models.EnumModels;

namespace Click.ViewModels.Selectors
{
    class OrdersSelector : DataTemplateSelector
    {
        public DataTemplate WaitingOrder { get; set; }
        public DataTemplate Header { get; set; }
        public DataTemplate DeliveredOrder { get; set; }

        public OrdersSelector()
        {
            WaitingOrder = new DataTemplate(typeof(Cell));
            Header = new DataTemplate(typeof(Cell));
            DeliveredOrder = new DataTemplate(typeof(Cell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            OrderLocal order = item as OrderLocal;
            if(order.Name == "")
            {
                return Header;
            }
            if (order.Delivered)
            {
                return DeliveredOrder;
            }
            else 
            {
                return WaitingOrder;
            }
        }
    }
}
