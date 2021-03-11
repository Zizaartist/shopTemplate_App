﻿using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Click.ViewModels
{
    public class CollectionViewModel : ViewModel
    {
        //Пагинация
        protected int NextPage { get; set; } = 0;
        protected int ItemTreshold { get; } = 1;

        public GetDataCommand GetMoreData { get; protected set; }
        public GetDataCommand GetInitialData { get; protected set; }

        public GetDataCommand NewGetDataCommand(Func<Task> _execute) 
        {
            return new GetDataCommand(_execute, () => IsNotBusy, (value) => IsBusy = value);
        }
    }
}
