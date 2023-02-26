using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseDesktopLib.Food
{
    public class Feeding
    {
        public int ID { get; set; } 
        public float Quantity { get; set; }
        public NutritionPlan Plan { get; set; }
        public Forage Forage { get; set; }
        public TimeSpan Time { get; set; }
    }
}
