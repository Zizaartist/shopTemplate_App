﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ApiClick.StaticValues;

namespace ApiClick.Models.EnumModels
{
    public enum OrderStatus 
    {
        sent, //Отправлен клиентом
        received, //Принят брендом (автоматически или через агрегатор)
        onWay, //Исполнитель утверждает что уже доставляет товар
        delivered, //Доставка произведена
        completed //Клиент подтвердил получение баллов
    }

    public class OrderStatusDictionaries 
    {
        public static Dictionary<OrderStatus, UserRole> GetMasterRoleFromOrderStatus = new Dictionary<OrderStatus, UserRole>() 
        {
            { OrderStatus.sent, UserRole.SuperAdmin },
            { OrderStatus.received, UserRole.Admin },
            { OrderStatus.onWay, UserRole.Admin },
            { OrderStatus.delivered, UserRole.Admin },
            { OrderStatus.completed, UserRole.User }
        };

        public static Dictionary<OrderStatus, string> GetStringFromOrderStatus = new Dictionary<OrderStatus, string>()
        {
            { OrderStatus.sent, "Отправлено" },
            { OrderStatus.received, "Принято" },
            { OrderStatus.onWay, "В пути" },
            { OrderStatus.delivered, "Доставлено" },
            { OrderStatus.completed, "Доставлено" }
        };

        public static Dictionary<string, OrderStatus> GetOrderStatusFromString = new Dictionary<string, OrderStatus>()
        {
            { "Отправлено", OrderStatus.sent },
            { "Принято", OrderStatus.received },
            { "В пути", OrderStatus.onWay },
            { "Доставлено", OrderStatus.delivered },
            { "Доставлено", OrderStatus.completed }
        };
    }
}
