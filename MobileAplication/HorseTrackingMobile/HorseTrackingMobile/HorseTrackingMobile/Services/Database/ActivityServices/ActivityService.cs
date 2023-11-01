using HorseTrackingMobile.Database;
using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services.Database.UserServices;
using HorseTrackingMobile.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Xamarin.Essentials;

namespace HorseTrackingMobile.Services.Database.ActivityServices
{
    public class ActivityService : IActivityService
    {
        private readonly IConnectionService _connectionService;
        private readonly IUserService _userService;

        public ActivityService(IConnectionService connectionServices, IUserService userService)
        {
            _connectionService = connectionServices;
            _userService = userService;
        }

        public List<Activity> GetActivities(int horseID)
        {
            var query = $"SELECT * FROM HorseTracking.dbo.Activities WHERE HorseID={horseID}";

            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            var reader = cmd.ExecuteReader();

            var activityList = new List<Activity>();
            while (reader.Read())
            {
                var activityToAdd = new Activity()
                {
                    ID = Convert.ToInt32(reader["activityID"]),
                    Type = ActivityType.ActivityTypeIdMap[Convert.ToInt32(reader["activityType"])],
                    Date = (DateTime)reader["date"],
                    Description = reader["description"].ToString(),
                };

                if (int.TryParse(reader["time"].ToString(), out var time))
                {
                    activityToAdd.Time = time;
                }
                else
                {
                    activityToAdd.Time = 0;
                }

                if (ActivityType.IsActiveActivity(activityToAdd.Type))
                {
                    activityToAdd.Trainer = _userService.GetTrainer(Convert.ToInt32(reader["trainerID"]));
                    activityToAdd.Satisfaction = Convert.ToInt32(reader["Satisfaction"]);
                    activityToAdd.Intensivity = Convert.ToInt32(reader["Intensivity"]);
                }
                activityList.Add(activityToAdd);
            }
            return activityList;
        }

        public void AddActivity(Activity activity)
        {
            string query;
            if (ActivityType.IsActiveActivity(activity.Type))
            {
                query = $"INSERT INTO Activities " +
                           $"(userID,activityType,trainerID,horseID,date,description,time,intensivity,satisfaction)" +
                           $"VALUES({activity.User?.Id},{activity.Type.ID},{activity.Trainer?.Id},{activity.Horse?.ID}," +
                           $"'{activity.Date.Year}.{activity.Date.Month}.{activity.Date.Day}','{activity.Description}',{activity.Time}," +
                           $"{activity.Intensivity},{activity.Satisfaction})";
            }
            else
            {
                query = $"INSERT INTO Activities " +
                           $"(userID,activityType,trainerID,horseID,date,description,time,intensivity,satisfaction)" +
                           $"VALUES({activity.User?.Id},{activity.Type?.ID},{activity.Trainer.Id},{activity.Horse?.ID}," +
                           $"'{activity.Date.Year}.{activity.Date.Month}.{activity.Date.Day}','{activity.Description}',{activity.Time}," +
                           $"{activity.Intensivity},{activity.Satisfaction})";
            }
            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            cmd.ExecuteReader();
        }

        public void EditActivity(int ID, Activity activity)
        {
            var query = $"UPDATE Activities " +
                $"SET userID = {activity.User?.Id}, activityType = {activity.Type?.ID}," +
                $"trainerID = {(activity.Trainer != null ? $"{activity.Trainer?.Id}" : "NULL")}," +
                $"horseID = {activity.Horse?.ID}, date='{activity.Date.Year}.{activity.Date.Month}.{activity.Date.Day}', " +
                $"description = '{activity.Description}', time = {activity.Time}, " +
                $"intensivity = {activity.Intensivity}, satisfaction = {activity.Satisfaction}" +
                $"WHERE activityID = {ID}";
            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            cmd.ExecuteReader();
        }

        public void DeleteActivity(int ID)
        {
            var query = $"Delete from Activities where activityID= {ID}";

            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            cmd.ExecuteReader();
        }
    }
}