using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services.Database.UserServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HorseTrackingMobile.Services.Database.CompetitionService
{
    public class CompetitionService : ICompetitionService
    {
        private IConnectionService _connectionService;

        public CompetitionService(IConnectionService connectionServices)
        {
            _connectionService = connectionServices;
        }

        public List<Participation> GetParticipation(int userID)
        {
            try
            {
                var query = $"SELECT *  FROM Participations as p inner join Competitions as c " +
                    $"on p.contestID =  c.competitionID inner join Horses as h on h.horseID = p.horseID " +
                    $"Where p.horseID in (Select horseID from Horses Where userID={userID})";
                var cmd = new SqlCommand(query, _connectionService.GetConnection());
                var reader = cmd.ExecuteReader();
                var list = new List<Participation>();

                while (reader.Read())
                {
                    list.Add(new Participation()
                    {
                        Result = reader["result"].ToString(),
                        Spot = reader["spot"].ToString(),
                        Place = reader["place"].ToString(),
                        Rank = reader["rank"].ToString(),
                        Date = (DateTime)reader["date"],
                        Description = reader["description"].ToString(),
                        HorseName = reader["name"].ToString()
                    });
                }
                return list.OrderByDescending(x => x.Date).ToList();
            }
            catch (Exception ex)
            {
                return new List<Participation>();
            }
        }
    }
}