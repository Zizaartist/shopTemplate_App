﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Click.Models
{
    public partial class Order
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public string DateTime { get; set; }
        public string Adress { get; set; }
        public string Price { get; set; }
        public bool Delivered { get; set; }
    }
}
