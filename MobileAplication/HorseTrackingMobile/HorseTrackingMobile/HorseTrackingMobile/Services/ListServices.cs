using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Services
{
    public class ListServices
    {
        public static bool IsAny<T>(List<T> list)
        {
            return list.Count == 0;
        }
    }
}
