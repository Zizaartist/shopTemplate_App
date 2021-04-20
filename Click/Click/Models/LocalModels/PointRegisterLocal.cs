using ApiClick.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Click.Models.LocalModels
{
    public class PointRegisterLocal
    {
        private PointRegister pointRegister;
        public PointRegister PointRegister
        {
            get => pointRegister;
            set
            {
                pointRegister = value;
                if (pointRegister.SenderId == null)
                {
                    Value = "+";
                }
                else
                {
                    Value = "-";
                }
            }
        }

        private string sign;
        public string Value
        {
            get => $"{sign} {PointRegister.Points}";
            set
            {
                sign = value;
            }
        }
    }
}
