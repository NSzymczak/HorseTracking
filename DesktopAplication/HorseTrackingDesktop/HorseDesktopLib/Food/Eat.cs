using HorseDesktopLib.Horses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseDesktopLib.Food
{
    public class Eat
    {
        public int ID { get; set; }
        public NutritionPlan Plan { get; set; }
        public Horse Horse { get; set; }
    }
}
