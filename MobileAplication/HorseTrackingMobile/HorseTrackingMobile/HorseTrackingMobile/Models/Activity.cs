using System;

namespace HorseTrackingMobile.Models
{
    public class Activity
    {
        public int ID { get; set; }

        public ActivityType Type { get; set; }

        public int TypeId { get; set; }

        public DateTime Date { get; set; }

        public int Satisfaction { get; set; }

        public int Intensivity { get; set; }

        public int Time { get; set; }

        public string Trener { get; set; }

        public string Description { get; set; }

    }
}
