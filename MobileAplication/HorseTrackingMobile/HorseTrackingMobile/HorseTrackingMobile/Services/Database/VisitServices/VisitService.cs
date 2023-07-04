using HorseTrackingMobile.Database;
using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services.AppState;
using HorseTrackingMobile.Services.Database.HorseServices;
using HorseTrackingMobile.Services.Database.UserServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HorseTrackingMobile.Services.Database.VisitServices
{
    public class VisitService : BaseDataService, IVisitService
    {
        private readonly IUserService _userService;
        private readonly IHorseService _horseService;
        private readonly IConnectionService _connectionService;
        private readonly IAppState _appState;

        public VisitService(IConnectionService connectionServices, IUserService userService, IHorseService horseService,
                            IAppState appState) : base(connectionServices)
        {
            _userService = userService;
            _horseService = horseService;
            _connectionService = connectionServices;
            _appState = appState;
            _appState.ListOfDoctors = GetDoctors();
        }

        public List<Visit> GetVisits(int horseID)
        {
            var query = $"SELECT * FROM Visits WHERE HorseID='{horseID}'";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();

            var visitList = new List<Visit>();
            while (reader.Read())
            {
                visitList.Add(new Visit()
                {
                    VisitID = Convert.ToInt32(reader["visitID"]),
                    Doctor = GetDoctor(Convert.ToInt32(reader["professionalID"])),
                    Cost = reader["cost"].ToString(),
                    VisitDate = (DateTime)reader["visitDate"],
                    Summary = reader["summary"].ToString(),
                    Horse = _horseService.GetHorse(reader["HorseID"].ToString())

                });
            }
            return visitList;
        }

        private Doctor GetDoctor(int id)
        {
            var query = $"SELECT * FROM Professionals WHERE professionalID='{id}'";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return new Doctor()
                {
                    DoctorID = Convert.ToInt32(reader["professionalID"]),
                    Details = _userService.GetDetails(Convert.ToInt32(reader["detailID"])),
                    Specialisation = GetSpecialisation(Convert.ToInt32(reader["specialisationID"])),
                };
            }
            return new Doctor();
        }

        private List<Doctor> GetDoctors()
        {
            var query = $"SELECT * FROM Professionals";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();
            var listOfDoctor = new List<Doctor>();
            while (reader.Read())
            {
                listOfDoctor.Add(new Doctor()
                {
                    DoctorID = Convert.ToInt32(reader["professionalID"]),
                    Details = _userService.GetDetails(Convert.ToInt32(reader["detailID"])),
                    Specialisation = GetSpecialisation(Convert.ToInt32(reader["specialisationID"])),
                });
            }
            return listOfDoctor;
        }

        private Specialisation GetSpecialisation(int id)
        {
            var query = $"SELECT * FROM Specialisations WHERE specialisationID='{id}'";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                return new Specialisation()
                {
                    SpecialisationID = Convert.ToInt32(reader["specialisationID"]),
                    Name = reader["name"].ToString()
                };
            }
            return new Specialisation();
        }
        public void AddVisit(Visit visit)
        {
            var query = $"INSERT INTO Visits (professionalID, horseID, visitDate, summary, cost)" +
                         $"VALUES({visit.Doctor?.DoctorID}, {visit.Horse?.ID}, " +
                         $"'{visit.VisitDate.Year}.{visit.VisitDate.Month}.{visit.VisitDate.Day}', '{visit.Summary}', '{visit.Cost}')";

            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            cmd.ExecuteReader();
        }

        public void EditVisit(int ID, Visit visit)
        {
            var query = $"UPDATE Visits " +
                $"SET professionalID = {visit.Doctor?.DoctorID}, horseID = {visit.Horse?.ID}," +
                $"visitDate = '{visit.VisitDate.Year}.{visit.VisitDate.Month}.{visit.VisitDate.Day}', " +
                $"summary = '{visit.Summary}', cost = {visit.Cost}" +
                $"WHERE visitID = {ID}";
            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            cmd.ExecuteReader();
        }

        public void DeleteVisit(int ID)
        {
            var query = $"Delete from Visits where visitID={ID}";

            var cmd = new SqlCommand(query, _connectionService.GetConnection());
            cmd.ExecuteReader();
        }
    }
}
