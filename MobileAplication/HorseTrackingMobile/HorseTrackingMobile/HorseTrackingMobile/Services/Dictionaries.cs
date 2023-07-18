using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HorseTrackingMobile.Services
{
    public class Dictionaries
    {
        public static Dictionary<int, string> UnitOfMeasure = new Dictionary<int, string>();

        public static Dictionary<int, string> MealsName = new Dictionary<int, string>();

        public static Dictionary<int, string> DayOfWeek = new Dictionary<int, string>()
        {
            {1,"Poniedziałek"},
            {2, "Wtorek"},
            {3, "Środa"},
            {4, "Czwartek"},
            {5, "Piątek"},
            {6, "Sobota"},
            {7, "Niedziela"}
        };

    }

    public class Enums
    {
        public enum UserTypes
        {
            horseOwner
        }

    }
}
