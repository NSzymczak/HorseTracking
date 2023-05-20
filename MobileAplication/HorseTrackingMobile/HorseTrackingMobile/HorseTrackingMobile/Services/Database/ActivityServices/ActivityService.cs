using HorseTrackingMobile.Database;
using HorseTrackingMobile.Models;
using HorseTrackingMobile.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HorseTrackingMobile.Services.Database.ActivityServices
{
    public class ActivityService : IActivityService
    {
        private readonly IConnectionService _connectionService;
        public ActivityService(IConnectionService connectionServices) 
        {
            _connectionService= connectionServices;
        }

        public List<Activity> GetActivities(int horseID)
        {
            var query = $"SELECT * FROM Activity WHERE HorseID='{horseID}'";

            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            var reader = cmd.ExecuteReader();

            var activityList = new List<Activity>();
            while (reader.Read())
            {
                activityList.Add(new Activity()
                {
                    ID = Convert.ToInt32(reader["activityID"]),
                    Type = ActivityType.ActivityTypeIdMap[Convert.ToInt32(reader["activityType"])],
                    Satisfaction = Convert.ToInt32(reader["Satisfaction"]),
                    Intensivity = Convert.ToInt32(reader["Intensivity"]),
                    Date = (DateTime)reader["date"],
                    Time = Convert.ToInt32(reader["time"] == null ? reader["time"] : 0),
                    Description = reader["description"].ToString(),
                });
            }
            return activityList;
        }

        public void AddActivity(Activity activity)
        {
            var query = $"INSERT INTO Activity " +
                        $"(activityID,userID,activityType,trainerID,horseID,date,description,time,intensivity,satisfaction)" +
                        $"VALUES({activity.ID},{activity.User?.Id},{activity.Type.ID},{activity.Trainer?.Id},{activity.Horse?.ID}," +
                        $"'{activity.Date.Year}.{activity.Date.Month}.{activity.Date.Day}','{activity.Description}',{activity.Time}," +
                        $"{activity.Intensivity},{activity.Satisfaction})";
            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            cmd.ExecuteReader();
        }

        public void EditActivity(int ID, Activity activity)
        {
            var quer = $"UPDATE Activity " +
                $"SET userID = {activity.User.Id}, activityType = {activity.Type.ID}, trainerID = {activity.Trainer.Id}," +
                $"horseID = {activity.Horse.ID}, date='{activity.Date.Year}.{activity.Date.Month}.{activity.Date.Day}', " +
                $"description = '{activity.Description}', time = {activity.Time}, " +
                $"intensivity = {activity.Intensivity}, satisfaction = {activity.Satisfaction}" +
                $"WHERE activityID = {ID}";
        }

        public void DeleteActivity(int ID) 
        { 
        
        }
    }
}
