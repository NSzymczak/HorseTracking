using HorseTrackingMobile.Database;
using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingMobile.Services
{
    public class ActivityDataManagement:IDataStoreActivity<Activity>
    {
        readonly List<Activity> activities;

        public ActivityDataManagement()
        {
            activities = TemporaryAdding.AddActivity();
        }

        public async Task<bool> AddActivityAsync(Activity activity)
        {
            activities.Add(activity);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateActivityAsync(Activity activity)
        {
            var oldItem = activities.Where((Activity arg) => arg.ID == activity.ID).FirstOrDefault();
            activities.Remove(oldItem);
            activities.Add(activity);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteActivityAsync(int id)
        {
            var oldItem = activities.Where((Activity arg) => arg.ID == id).FirstOrDefault();
            activities.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Activity> GetActivityAsync(int id)
        {
            return await Task.FromResult(activities.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<Activity>> GetActivitiesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(activities);
        }
    }
}
