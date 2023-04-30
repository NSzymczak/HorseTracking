using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HorseTrackingMobile.Database.VisitServices
{
    public class VisitService : BaseService, IVisitService
    {
        public VisitService(IConnectionService connectionServices) : base(connectionServices) { }

        public List<Visit> GetVisits(int visitID)
        {
            var query = $"SELECT * FROM Visit WHERE HorseID='{visitID}'";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();

            var visitList = new List<Visit>();
            while (reader.Read())
            {
                visitList.Add(new Visit()
                {
                    VisitID = Convert.ToInt32(reader["careID"]),
                    Doctor = GetDoctor(Convert.ToInt32(reader["doctorID"])),
                    Cost = reader["cost"].ToString(),
                    VisitDate = (DateTime)reader["visitDate"],
                    Summary = reader["summary"].ToString()

                });
            }
            return visitList;
        }

        private Doctor GetDoctor(int id)
        {
            var query = $"SELECT * FROM Doctor WHERE doctorID='{id}'";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return new Doctor()
                {
                    DoctorID = Convert.ToInt32(reader["doctorID"]),
                    Details = GetDetails(Convert.ToInt32(reader["detailsID"])),
                    Specialisation = GetSpecialisation(Convert.ToInt32(reader["specialisationID"])),
                };
            }
            return new Doctor();
        }

        private Specialisation GetSpecialisation(int id)
        {
            var query = $"SELECT * FROM DoctorSpecialisation WHERE specialisationID='{id}'";

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

        private PeopleDetails GetDetails(int id)
        {
            string query = $"SELECT * FROM PeopleDetails WHERE detailsID='{id}'";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return new PeopleDetails()
                {
                    ID = Convert.ToInt32(reader["detailsID"]),
                    Name = reader["name"].ToString(),
                    Surname = reader["surname"].ToString(),
                    PhoneNumber = reader["phoneNumber"].ToString(),
                    Email = reader["email"].ToString(),
                    City = reader["city"].ToString(),
                    Street = reader["street"].ToString(),
                    Number = reader["number"].ToString(),
                };
            }
            return new PeopleDetails();
        }
    }
}
