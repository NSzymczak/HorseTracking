using HorseTrackingMobile.Enumerable;
using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services.Database.UserServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingMobile.Services.Database.ShareHorseServices
{
    public class ShareHorseServices : IShareHorseServices
    {
        private readonly IConnectionService _connectionService;
        private readonly IUserService _userService;

        public ShareHorseServices(IConnectionService connectionServices, IUserService userService)
        {
            _connectionService = connectionServices;
            _userService = userService;
        }

        public void SaveShareFromQR(string horseID, DateTime startDate, DateTime endDate,
            string userScanID, string userShareID)
        {
            var query = $"INSERT INTO Shareds ([horseID],[userShareID],[userScanID],[endDate],[startDate],[code])" +
                $" VALUES ({horseID}, {userShareID}, {userScanID}, '{endDate.Date.Year}.{endDate.Date.Month}.{endDate.Date.Day}', " +
                $"'{startDate.Date.Year}.{startDate.Date.Month}.{startDate.Date.Day}', 00 ) ";
            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            cmd.ExecuteReader();
            SetStatus(horseID);
        }

        public bool CheckShared(string horseID)
        {
            var query = $"SELECT DISTINCT horseID  FROM Shareds  Where horseID={horseID}";
            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            var reader = cmd.ExecuteReader();
            return !reader.HasRows;
        }

        public void DelateOutdated()
        {
            //First change status to active
            var query = $"SELECT horseID FROM Shareds WHERE endDate < GETDATE()";
            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            cmd.ExecuteReader();
            ChangeStatusToActive(query);
        }

        private void ChangeStatusToActive(string insideQuery)
        {
            var query = $"Update Horses set statusID=(Select statusID from Status where name = '{StatusEnum.active}') " +
                $"where horseID IN ({insideQuery});";
            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            cmd.ExecuteReader();
        }

        public bool HasSharedHorses(string userID)
        {
            var query = $"SELECT DISTINCT userScanID  FROM Shareds  Where userScanID={userID}";
            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            var reader = cmd.ExecuteReader();
            return reader.HasRows;
        }

        public List<Horse> GetSharedHorses(string userID)
        {
            DelateOutdated();
            var query = $"SELECT * FROM Horses WHERE horseID IN (SELECT DISTINCT horseID  FROM Shareds  Where userScanID={userID})";
            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            var reader = cmd.ExecuteReader();

            var horseList = new List<Horse>();
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

        public void SetStatus(string horseShared)
        {
            var query = $"UPDATE Horses " +
                $"SET statusID = (Select statusID from Status where name = '{StatusEnum.shared}')" +
                $"WHERE horseID = {horseShared}";
            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            cmd.ExecuteReader();
        }

        public void CleanShare(string userID)
        {
            var query = $"SELECT horseID FROM Shareds WHERE userScanID = {userID}";
            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            cmd.ExecuteReader();
            ChangeStatusToActive(query);
        }
    }
}