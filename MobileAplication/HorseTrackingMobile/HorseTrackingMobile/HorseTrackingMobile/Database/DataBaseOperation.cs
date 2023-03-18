using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace HorseTrackingMobile.Database
{
    public class DataBaseOperation
    {
        public static List<User> GetAllUsers()
        {
            return TemporaryAdding.AddUser(); //zastapic pobieraniem z bazy danych
        }

        public static User GetLoggedUser()
        {
            var id = Preferences.Get(PreferencesKeys.UserID, 0);
            return GetAllUsers().Where(x => x.Id == id).FirstOrDefault();
        }

        public static List<Horse> GetAllUserHorses()
        {
            return TemporaryAdding.AddHorse().Where(x => x.User.Id == User.CurrentUser.Id).ToList();
        }
    }
}
