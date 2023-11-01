using HorseTrackingMobile.Database;
using HorseTrackingMobile.Enumerable;
using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services.AppState;
using HorseTrackingMobile.Services.Database.ShareHorseServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HorseTrackingMobile.Services.Database.HorseServices
{
    public class HorseService : BaseDataService, IHorseService
    {
        private readonly IAppState _appState;
        private readonly IShareHorseServices _shareHorseServices;

        public HorseService(IConnectionService connectionServices, IAppState appState,
            IShareHorseServices shareHorseServices) : base(connectionServices)
        {
            _appState = appState;
            _shareHorseServices = shareHorseServices;
        }

        public Horse GetHorse(string id)
        {
            string query = $"SELECT horseID, h.name, birthday, s.name " +
                $"FROM Horses as h inner join Status as s on h.statusID=s.statusID " +
                $"WHERE horseID={id} AND s.name ='{StatusEnum.active}'";

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

        public List<Horse> GetHorsesForUser()
        {
            var horseList = new List<Horse>();
            var userID = _appState.CurrentUser.Id.ToString();
            if (_appState.CurrentUser.Type.Type == "horseOwner")
            {
                horseList = GetHorses(userID);
            }
            else if (_appState.CurrentUser.Type.Type == "trainer")
            {
                horseList = GetAllTrainedHorses(userID);
            }
            if (_shareHorseServices.HasSharedHorses(userID))
            {
                var sharedhorses = _shareHorseServices.GetSharedHorses(userID);
                foreach (var sharedHorse in sharedhorses)
                {
                    horseList.Add(sharedHorse);
                }
            }
            return horseList;
        }

        public List<Horse> GetHorses(string userID)
        {
            string query = $"SELECT horseID, h.name, birthday, s.name " +
                           $"FROM Horses as h inner join Status as s on h.statusID=s.statusID " +
                           $"WHERE UserID={userID} AND s.name ='{StatusEnum.active}'";
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

        public List<Horse> GetAllTrainedHorses(string user)
        {
            string query = $"SELECT DISTINCT h.horseID, genderID, h.userID, h.name,mother, father, birthday, race, " +
                $"breeder, passport, s.name FROM Horses as h inner join Activities as a on h.horseID = a.horseID " +
                $"inner join Status as s on h.statusID= s.statusID Where s.name = '{StatusEnum.active}' AND userID={user}";

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