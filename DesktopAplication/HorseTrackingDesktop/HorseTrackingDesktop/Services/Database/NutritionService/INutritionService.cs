using HorseTrackingDesktop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Database.NutritionService
{
    public interface INutritionService
    {
        Task<IEnumerable<NutritionPlans>> GetPlanForHorse(int horseID);

        Task<IEnumerable<NutritionPlans>> GetPlanForHorses(int[] horsesID);

        public Task<IEnumerable<MealNames>> GetMealName();

        public Task<IEnumerable<Forages>> GetForage();

        public Task<IEnumerable<UnitOfMeasures>> GetUnitOfMeasure();

        Task AddNutritionPlan(NutritionPlans nutrition);

        Task<bool> HorseHasDiet(Horses horses);

        Task ChangeDiet(Horses horses, NutritionPlans nutritionPlans);

        Task<IEnumerable<Meals>> GetMealsForPlan(int id);
    }
}