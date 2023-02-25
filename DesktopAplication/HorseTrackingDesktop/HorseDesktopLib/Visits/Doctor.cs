using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseDesktopLib.Visits
{
    public class Doctor
    {
        public int ID { get; set; }
        public Specialisation? Specialisation { get; set; }
        public PeopleDetails? Details { get; set; }
    }
}
