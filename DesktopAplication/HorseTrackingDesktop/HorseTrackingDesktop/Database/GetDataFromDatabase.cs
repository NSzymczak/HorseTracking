using HorseTrackingDesktop.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Database
{
    public class GetDataFromDatabase
    {

        public static async Task GetAllActivities()
        {
            using (var context = new HorseTrackingContext())
            {
                Activity.activities = await context.Activity.ToListAsync();
            }
        }


        private static async void GetHorseActivities()
        {
            using (var context = new HorseTrackingContext())
            {
                Activity.activities = await context.Activity.Where(x => x.UserId == UserAcount.CurrentUser.UserId).ToListAsync();
            }
        }


        public static void GetUser(string login, string hash)
        {
            using (var context = new HorseTrackingContext())
            {
                UserAcount.CurrentUser = context.UserAcount.Where(x => x.AcountLogin == login).ToList().FirstOrDefault();
            }
        }

        private static async void GetHorses(UserAcount user)
        {
            using (var context = new HorseTrackingContext())
            {
                 Horse.Horses= await context.Horse.Where(x => x.UserId == user.UserId).ToListAsync();
            }
        }

    }
}
