using System;
using System.Collections.Generic;
using System.Text;

namespace Click.ViewModels
{
    public class CollectionViewModel : ViewModel
    {
        //Пагинация
        protected int Page { get; set; } = 0;
        //не позволит работать 2м командам одновременно
        private bool getDataLock = false;
        public bool GetDataLock 
        {
            get => getDataLock;
            set 
            {
                if (getDataLock == value) return;
                getDataLock = value;
                OnPropertyChanged();
            }
        }

        protected int ItemTreshold { get; } = 1;
        public GetDataCommand GetMoreData { get; protected set; }
        public GetDataCommand GetInitialData { get; protected set; }
    }
}
