using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string MealName { get; set; }
        public List<Feeding> Feedings { get; set; }
    }
}
