using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Xamarin.Essentials;

namespace HorseTrackingMobile.Services.Database
{
    public class DataBaseConnection
    {
        private static string dbName = "HorseTracking";
        //private static string serverName = "tcp:192.168.88.249,1433"; //Głuchołazy
        //private static string serverName = "tcp:192.168.1.19,1433"; //Opole
        private static string serverName = "tcp:192.168.10.118,1433"; //Kondradów
        private static string serverUserName = "Natka";
        private static string serverPassword = "123456";
        private static string connectionString = $"Data Source={serverName}; Initial Catalog={dbName}; User id={serverUserName}; Password={serverPassword}; Connection Timeout = 10; MultipleActiveResultSets=true";
        private static SqlConnection sqlConnection;

        public static void Connect()
        {
            sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Błąd", ex.Message, "OK");
            }
        }

        public static List<User> GetAllUsers()
        {
            string query = $"SELECT * FROM UserAcount";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            List<User> userList = new List<User>();
            while (reader.Read())
            {
                userList.Add(new User()
                {
                    Id = Convert.ToInt32(reader["userID"]),
                    Type = new UserType()
                    {
                        ID = Convert.ToInt32(reader["userTypeID"])
                    },
                    Details = new PeopleDetails()
                    {
                        ID = Convert.ToInt32(reader["detailsID"])
                    },
                    Login = reader["acountLogin"].ToString(),
                    Hash = reader["hash"].ToString(),
                    Salt = reader["salt"].ToString(),
                    CreatedDate = (DateTime)reader["createdDate"]
                });
            }
            return userList;
        }
        public static User GetLoggedUser()
        {
            var id = Preferences.Get(PreferencesKeys.UserID, 0);
            return GetAllUsers().Where(x => x.Id == id).FirstOrDefault();
        }
        public static List<Horse> GetHorses()
        {
            Connect();
            string query = $"SELECT horseID,name,birthday FROM Horse WHERE UserID='{User.CurrentUser.Id}'";

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
            Horse.HorseList = horseList;
            return horseList;
        }
        public static List<Activity> GetActivity(int id)
        {
            string query = $"SELECT * FROM Activity WHERE HorseID='{id}'";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Activity> activityList = new List<Activity>();
            while (reader.Read())
            {
                Activity activity = new Activity();
                activity.ID = Convert.ToInt32(reader["activityID"]);
                activity.Type = ActivityType.ActivityTypeIdMap[Convert.ToInt32(reader["activityType"])];
                activity.Satisfaction = Convert.ToInt32(reader["Satisfaction"]);
                activity.Intensivity = Convert.ToInt32(reader["Intensivity"]);
                activity.Date = (DateTime)reader["date"];
                activity.Time = Convert.ToInt32(reader["time"] == null ? reader["time"] : 0);
                activity.Description = reader["description"].ToString();
                activityList.Add(activity);
            }
            return activityList;
        }
        public static List<Visit> GetVisits(int id)
        {
            string query = $"SELECT * FROM Visit WHERE HorseID='{id}'";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Visit> visitList = new List<Visit>();
            while (reader.Read())
            {
                Visit visit = new Visit();
                visit.VisitID = Convert.ToInt32(reader["careID"]);
                visit.Doctor = GetDoctor(Convert.ToInt32(reader["doctorID"]));
                visit.Cost = reader["cost"].ToString();
                visit.VisitDate = (DateTime)reader["visitDate"];
                visit.Summary = reader["summary"].ToString();
                visitList.Add(visit);
            }
            return visitList;
        }
        private static Doctor GetDoctor(int id)
        {
            string query = $"SELECT * FROM Doctor WHERE doctorID='{id}'";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();
            var doctor = new Doctor();
            while (reader.Read())
            {
                doctor.DoctorID = Convert.ToInt32(reader["doctorID"]);
                doctor.Details = GetDetails(Convert.ToInt32(reader["detailsID"]));
                doctor.Specialisation = GetSpecialisation(Convert.ToInt32(reader["specialisationID"]));
            }
            return doctor;
        }
        private static PeopleDetails GetDetails(int id)
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
            return null;
        }
        public static Specialisation GetSpecialisation(int id)
        {
            string query = $"SELECT * FROM DoctorSpecialisation WHERE specialisationID='{id}'";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();
            var d = new Specialisation();
            while (reader.Read())
            {
                d.SpecialisationID = Convert.ToInt32(reader["specialisationID"]);
                d.Name = reader["name"].ToString();
            }
            return d;
        }
        public static void GetUnitOfMeasure()
        {
            string query = $"SELECT * FROM UnitOfMeasure";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Dictionaries.UnitOfMeasure.Add(Convert.ToInt32(reader["unitID"]), reader["unitName"].ToString());
            }
        }
        public static void GetMealsName()
        {
            string query = $"SELECT * FROM MealName";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Dictionaries.MealsName.Add(Convert.ToInt32(reader["mealNameID"]), reader["mealName"].ToString());
            }
        }
        public static Forage GetForage(int forageID)
        {
            string query = $"SELECT * FROM Forage WHERE forageID={forageID}";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                return new Forage()
                {
                    Id = Convert.ToInt32(reader["forageID"]),
                    Name = reader["name"].ToString(),
                    Capacity = Convert.ToInt32(reader["capacity"]),
                    Producent = reader["producent"].ToString(),
                    UnitOfMeasure = Dictionaries.UnitOfMeasure[Convert.ToInt32(reader["unitOfMeasure"])],
                };
            }
            return null;
        }
        public static NutritionPlan GetNutritionPlansForHorse(int horseID)
        {
            string query = $"SELECT * FROM NutritionPlan AS n inner join Eat AS e ON  n.nutritionPlanID = e.nutritionPlanID WHERE horseID={horseID}";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                return new NutritionPlan()
                {
                    ID = Convert.ToInt32(reader["nutritionPlanID"]),
                    Title = reader["title"].ToString(),
                    Description = reader["description"].ToString(),
                    Icon = reader["icon"].ToString(),
                    Color = reader["color"].ToString(),
                    Meals = GetMeals(Convert.ToInt32(reader["nutritionPlanID"]))
                };
            }
            return null;
        }
        public static List<Meal> GetMeals(int id)
        {
            string query = $"SELECT * FROM Meal WHERE nutritionID={id}";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();
            var listOfMeals = new List<Meal>();

            while (reader.Read())
            {
                listOfMeals.Add(new Meal()
                {
                    Id = Convert.ToInt32(reader["mealID"]),
                    MealName = Dictionaries.MealsName[Convert.ToInt32(reader["mealNameID"])],
                    Feedings = GetFeeding(id, Convert.ToInt32(reader["mealID"])),
                });
            }
            return listOfMeals;
        }
        public static List<Feeding> GetFeeding(int nutritionId, int mealId)
        {
            string query = $"SELECT * FROM Feeding Where mealID={mealId}";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();
            var listOfFeeding = new List<Feeding>();

            while (reader.Read())
            {
                listOfFeeding.Add(
                    new Feeding()
                    {
                        Id = Convert.ToInt32(reader["feedID"]),
                        Forage = GetForage(Convert.ToInt32(reader["forageID"])),
                        Unit = Dictionaries.UnitOfMeasure[Convert.ToInt32(reader["unitID"])],
                        MealID = Convert.ToInt32(reader["mealID"]),
                        Amount = reader["amount"].ToString(),
                    });
            }
            return listOfFeeding;
        }
    }
}
