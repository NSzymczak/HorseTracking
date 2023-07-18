using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HorseTrackingMobile.Services
{
    public class ListServices
    {
        public static bool IsAny<T>(List<T> list)
        {
            return list==null || list.Count == 0;
        }
        public static bool IsAny<T>(ObservableCollection<T> collection)
        {
            return collection==null || collection.Count == 0;
        }
    }
}
