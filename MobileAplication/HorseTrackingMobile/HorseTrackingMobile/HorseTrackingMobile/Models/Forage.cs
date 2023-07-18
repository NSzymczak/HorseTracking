using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Models
{
    public class Forage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Producent { get; set; }
        public int Capacity { get; set; }
        public string UnitOfMeasure { get; set; }
        public int MealID { get; set; }

    }
}
