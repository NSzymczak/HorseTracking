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

        public Horse GetHorse(string id)
        {
            string query = $"SELECT horseID,name,birthday FROM Horses WHERE horseID='{id}'";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                return new Horse()
                {
                    ID = Convert.ToInt32(reader["horseID"]),
                    Name = reader["name"].ToString(),
                    Birthday = (DateTime)reader["birthday"],
                };
            }
            return new Horse();
        }

        public List<Horse> GetHorses(User user)
        {
            string query = $"SELECT horseID,name,birthday FROM Horses WHERE UserID='{user.Id}'";

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

        public List<Horse> GetAllTrainedHorses(User user)
        {
            string query = $"SELECT DISTINCT h.horseID, genderID, h.userID, name,mother, father, birthday, race, breeder, passport" +
                $" FROM Horses as h inner join Activities as a on h.horseID = a.horseID Where a.trainerID = {user.Id}";

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
