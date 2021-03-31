using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Click.ViewModels.Help
{
    public class Grouping<K, T> : ObservableCollection<T>
    {
        public K Name { get; private set; }
        public string Logo { get; set; }
        public string DeliveryConditions { get; set; }
        public Grouping(K name, string logo, string deliveryCondition, IEnumerable<T> items)
        {
            Name = name;
            Logo = logo;
            DeliveryConditions = deliveryCondition;
            foreach (T item in items)
                Items.Add(item);
        }
    }
}
