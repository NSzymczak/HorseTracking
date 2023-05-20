using HorseTrackingMobile.Database;
using HorseTrackingMobile.Models;
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
    }
}
