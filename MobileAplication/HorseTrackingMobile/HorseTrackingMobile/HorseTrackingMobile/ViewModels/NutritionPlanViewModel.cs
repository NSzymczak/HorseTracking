using HorseTrackingMobile.Database;
using HorseTrackingMobile.Database.NutritionServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Xaml;

namespace HorseTrackingMobile.ViewModels
{
    public class NutritionPlanViewModel : HorseAppViewModel
    {
        private readonly INutritionService _nutritionService;
        public NutritionPlanViewModel(INutritionService nutritionService) 
        {
            _nutritionService = nutritionService;

            _nutritionService.GetUnitOfMeasure();
            _nutritionService.GetMealsName();
        }

        public void Load()
        {
            if (Horses == null)
            {
                return;
            }
            foreach(var horse in Horses)
            {
                horse.Plan = _nutritionService.GetNutritionPlan(horse.ID);
            }
        }
    }
}
