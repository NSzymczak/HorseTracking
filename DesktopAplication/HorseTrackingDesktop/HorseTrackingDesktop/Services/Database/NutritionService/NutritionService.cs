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
                                  .AsEnumerable();

            return Task.FromResult(nutritionPlans);
        }

        public Task<IEnumerable<NutritionPlans>> GetPlanForHorses(int[] horsesID)
        {
            var nutritionPlans = _context.Diets.Where(h => horsesID.Contains(h.HorseId))
                                  .Include(n => n.NutritionPlan)
                                  .ThenInclude(m => m.Meals)
                                  .ThenInclude(p => p.Portions)
                                  .ThenInclude(u => u.Unit)
                                  .Include(n => n.NutritionPlan)
                                  .ThenInclude(m => m.Meals)
                                  .ThenInclude(p => p.Portions)
                                  .ThenInclude(f => f.Forage)
                                  .Include(n => n.NutritionPlan)
                                  .ThenInclude(m => m.Meals)
                                  .ThenInclude(p => p.MealName)
                                  .Include(n => n.NutritionPlan)
                                  .ThenInclude(d => d.Diets)
                                  .Select(n => n.NutritionPlan)
                                  .Distinct()
                                  .AsEnumerable().ToList();

            return Task.FromResult(nutritionPlans.AsEnumerable());
        }

        public Task<IEnumerable<MealNames>> GetMealName()
        {
            return Task.FromResult(_context.MealNames.AsEnumerable());
        }

        public Task<IEnumerable<Forages>> GetForage()
        {
            return Task.FromResult(_context.Forages.AsEnumerable());
        }

        public Task<IEnumerable<UnitOfMeasures>> GetUnitOfMeasure()
        {
            return Task.FromResult(_context.UnitOfMeasures.AsEnumerable());
        }

        public Task AddNutritionPlan(NutritionPlans nutrition)
        {
            _context.NutritionPlans.Add(nutrition);
            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}