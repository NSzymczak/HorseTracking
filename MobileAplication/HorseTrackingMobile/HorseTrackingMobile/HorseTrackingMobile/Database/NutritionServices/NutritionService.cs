using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HorseTrackingMobile.Database.NutritionServices
{
    public class NutritionService : BaseService, INutritionService
    {
        public NutritionService(IConnectionService connectionServices) : base(connectionServices) { }

        public void GetUnitOfMeasure()
        {
            string query = $"SELECT * FROM UnitOfMeasure";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Dictionaries.UnitOfMeasure.Add(Convert.ToInt32(reader["unitID"]), reader["unitName"].ToString());
            }
        }
        public void GetMealsName()
        {
            string query = $"SELECT * FROM MealName";

            var cmd = new SqlCommand(query, sqlConnection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Dictionaries.MealsName.Add(Convert.ToInt32(reader["mealNameID"]), reader["mealName"].ToString());
            }
        }
        private Forage GetForage(int forageID)
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
        public NutritionPlan GetNutritionPlan(int horseID)
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
        private List<Meal> GetMeals(int id)
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
        private List<Feeding> GetFeeding(int nutritionId, int mealId)
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
