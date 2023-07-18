using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HorseTrackingMobile.Models
{
    public class DayOfActivity
    {
        public string Label { get; set; }
        public DateTime DateTime { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public ObservableCollection<Activity> ListOfActivity { get; set; }


    }
}
