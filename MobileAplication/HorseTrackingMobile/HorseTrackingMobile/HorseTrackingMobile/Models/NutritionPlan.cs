using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HorseTrackingMobile.Models
{
    public class NutritionPlan
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public List<Meal> Meals { get; set; }

    }
}
