﻿using ApiClick.Models.EnumModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiClick.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
            PointRegisters = new HashSet<PointRegister>();
        }

        public int OrderId { get; set; }
        public int OrdererId { get; set; }
        public Kind Kind { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public bool? PointsUsed { get; set; }
        public decimal? DeliveryPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? BrandId { get; set; }

        
        public virtual OrderInfo OrderInfo { get; set; }
        public virtual WaterOrder WaterOrder { get; set; }
        public Brand Brand { get; set; }
        [JsonIgnore]
        public User Orderer { get; set; }
        [JsonIgnore]
        public Review Review { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [JsonIgnore]
        public virtual ICollection<PointRegister> PointRegisters { get; set; }

        [NotMapped]
        public bool Delivery { get; set; } //Получаем от клиента
        [NotMapped]
        [JsonIgnore]
        public PointRegister PointRegister
        {
            get 
            {
                return PointRegisters?.FirstOrDefault(pr => pr.SenderId == OrdererId);
            }
        }
        [NotMapped]
        public decimal Sum { get; set; }
        [NotMapped]
        public string OrdererName { get; set; }
    }
}
