using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public Specialisation Specialisation { get; set; }
        public PeopleDetails Details { get; set; }
    }
}
