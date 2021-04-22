using ApiClick.Models;
using ShopAdminAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Click.Models.LocalModels
{
    public class PointRegisterLocal
    {
        public PointRegister PointRegister { get; set; }

        public string Sign { get => PointRegister.UsedOrReceived ? "-" : "+"; }
        public string Value { get => $"{Sign} {PointRegister.Points}"; }
    }
}
