using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Models
{
    public class Feeding
    {
        public int Id { get; set; }
        public int MealID { get; set; }
        public string Amount { get; set; }
        public string Unit { get; set; }
        public Forage Forage { get; set; }
    }
}
