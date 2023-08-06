using HorseTrackingDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}