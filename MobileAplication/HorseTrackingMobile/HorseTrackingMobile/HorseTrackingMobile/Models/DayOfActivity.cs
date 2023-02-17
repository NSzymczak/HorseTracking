using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Models
{
    public class DayOfActivity
    {
        public string Label { get; set; }
        public DateTime DateTime { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public List<Activity> ListOfActivity { get; set; }


    }
}
