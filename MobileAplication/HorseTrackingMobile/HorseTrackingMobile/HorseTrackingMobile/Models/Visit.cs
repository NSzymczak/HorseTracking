using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Models
{
    public class Visit
    {
        public int VisitID { get; set; }
        public string Cost { get; set; }
        public string Summary { get; set; }
        public DateTime VisitDate { get; set; }
        public PeopleDetails Details { get; set; }

        public Doctor Doctor { get; set; }
    }
}
