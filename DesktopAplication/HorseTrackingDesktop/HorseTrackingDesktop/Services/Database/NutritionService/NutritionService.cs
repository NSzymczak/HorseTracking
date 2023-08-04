using HorseTrackingDesktop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Database.NutritionService
{
    public class NutritionService : INutritionService
    {
        private readonly HorseTrackingContext _context;

        public NutritionService(HorseTrackingContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<NutritionPlans>> GetPlanForHorse(int horseID)
        {
            var nutritionPlans = _context.Diets.Where(h => h.HorseId == horseID)
                                  .Include(n => n.NutritionPlan)
                                  .ThenInclude(m => m.Meals)
                                  .ThenInclude(p => p.Portions)
                                  .ThenInclude(u => u.Unit)
                                  .Include(n => n.NutritionPlan)
                                  .ThenInclude(m => m.Meals)
                                  .ThenInclude(p => p.Portions)
                                  .ThenInclude(f => f.Forage)
                                  .Select(n => n.NutritionPlan)
                                  .AsEnumerable().ToList();

            return Task.FromResult(nutritionPlans.AsEnumerable());
        }

        public List<NutritionPlans> GetPlanForHorses(int[] horsesID)
        {
            return new List<NutritionPlans>();
        }
    }
}