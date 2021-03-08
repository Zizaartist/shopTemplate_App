using ApiClick.Models.EnumModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClick.Models.ArrayModels
{
    public class ScheduleListElement
    {
        [Key]
        public int ScheduleListElementId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public int? BrandId { get; set; } //Не обязательно для предотвращения капризов

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
    }

    public class DayOfWeekDictionaries 
    {
        public static Dictionary<DayOfWeek, string> GetStringFromDayOfWeek = new Dictionary<DayOfWeek, string>() 
        {
            { DayOfWeek.Sunday, "ВС" },
            { DayOfWeek.Monday, "ПН" },
            { DayOfWeek.Tuesday, "ВТ" },
            { DayOfWeek.Wednesday, "СР" },
            { DayOfWeek.Thursday, "ЧТ" },
            { DayOfWeek.Friday, "ПТ" },
            { DayOfWeek.Saturday, "СБ" },
        };

        public static List<DayOfWeek> CorrectlyOrderedDays = new List<DayOfWeek>()
            {
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            };
    }
}
