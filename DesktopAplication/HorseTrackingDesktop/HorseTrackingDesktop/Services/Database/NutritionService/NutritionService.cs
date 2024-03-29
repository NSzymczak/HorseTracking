﻿using HorseTrackingDesktop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<IEnumerable<Meals>> GetMealsForPlan(int id)
        {
            var meals = _context.Meals.Where(m => m.NutritionPlanId == id)
                .Include(p => p.Portions).ThenInclude(u => u.Unit)
                .Include(p => p.Portions).ThenInclude(f => f.Forage)
                .Include(m => m.MealName).AsEnumerable();
            return Task.FromResult(meals);
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
            var editPlan = _context.NutritionPlans.FirstOrDefault(x => x.NutritionPlanId == nutrition.NutritionPlanId);
            if (nutrition.Color == null || nutrition.Color == String.Empty)
            {
                nutrition.Color = "#000000";
            }
            if (editPlan != null)
            {
                var id = editPlan.NutritionPlanId;
                editPlan.Title = nutrition.Title;
                editPlan.Description = nutrition.Description;
                editPlan.Color = nutrition.Color;
                editPlan.Icon = nutrition.Icon;
                _context.Entry(editPlan).State = EntityState.Modified;
            }
            else
            {
                _context.NutritionPlans.Add(nutrition);
            }
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<bool> HorseHasDiet(Horses horses)
        {
            var diets = _context.Diets.Where(x => x.HorseId == horses.HorseId);
            if (diets.Any())
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task ChangeDiet(Horses horses, NutritionPlans nutritionPlans)
        {
            var diets = _context.Diets.Where(x => x.HorseId == horses.HorseId).FirstOrDefault();
            var nutritionID = _context.NutritionPlans.Where(x => x.NutritionPlanId == nutritionPlans.NutritionPlanId).Select(x => x.NutritionPlanId).FirstOrDefault();

            if (diets != null)
            {
                diets.NutritionPlanId = nutritionID;
            }
            else
            {
                diets = new Diets()
                {
                    Horse = horses,
                    NutritionPlanId = nutritionID,
                    IsActive = true
                };
            }
            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}