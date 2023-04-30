using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HorseTrackingMobile.Database.ActivityServices
{
    public class ActivityService : BaseService, IActivityService
    {
        public ActivityService(IConnectionService connectionServices) : base(connectionServices) { }

        public List<Activity> GetActivities(int horseID)
        {
            var query = $"SELECT * FROM Activity WHERE HorseID='{horseID}'";

            var cmd = new SqlCommand(query, sqlConnection);
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
