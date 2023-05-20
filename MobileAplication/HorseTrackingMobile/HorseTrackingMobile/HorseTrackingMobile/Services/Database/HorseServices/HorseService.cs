using HorseTrackingMobile.Database;
using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HorseTrackingMobile.Services.Database.HorseServices
{
    public class HorseService : BaseDataService, IHorseService
    {
        public HorseService(IConnectionService connectionServices) : base(connectionServices) { }

        public List<Horse> GetHorses(User user)
        {
            string query = $"SELECT horseID,name,birthday FROM Horse WHERE UserID='{user.Id}'";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Horse> horseList = new List<Horse>();
            while (reader.Read())
            {
                horseList.Add(new Horse()
                {
                    ID = Convert.ToInt32(reader["horseID"]),
                    Name = reader["name"].ToString(),
                    Birthday = (DateTime)reader["birthday"],
                });
            }
            return horseList;
        }
    }
}
