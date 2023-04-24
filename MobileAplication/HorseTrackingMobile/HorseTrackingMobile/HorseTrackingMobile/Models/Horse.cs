using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace HorseTrackingMobile.Models
{
    public class Horse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public User User { get; set; }
        public string Mother { get; set; }
        public string Father { get; set; }
        public DateTime Birthday { get; set; }
        public string Race { get; set; }
        public string Breeder { get; set; }
        public string Passport { get; set; }
        public Image Photo { get; set; }
        public HorseStatus Status { get; set; }

        public static List<Horse> HorseList { get; set; }
    }
}
