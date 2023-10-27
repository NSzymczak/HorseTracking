using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Models
{
    public class Participation
    {
        public string Result { get; set; }
        public string Place { get; set; }
        public string Spot { get; set; }
        public string Rank { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string HorseName { get; set; }
    }
}