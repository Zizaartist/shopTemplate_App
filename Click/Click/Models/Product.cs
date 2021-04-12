﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiClick.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Reports = new HashSet<Report>();
        }

        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int? PriceDiscount { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        
        public DateTime CreatedDate { get; set; }

        
        public Category Category { get; set; }
        
        public ICollection<Report> Reports { get; set; }
        
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
