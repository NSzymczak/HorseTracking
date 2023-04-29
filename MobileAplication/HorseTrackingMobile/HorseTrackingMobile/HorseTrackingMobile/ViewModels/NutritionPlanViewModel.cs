using HorseTrackingMobile.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.ViewModels
{
    public class NutritionPlanViewModel : HorseAppViewModel
    {
        public NutritionPlanViewModel() 
        {
            DataBaseConnection.GetUnitOfMeasure();
            DataBaseConnection.GetMealsName();
        }

        public void Load()
        {
            foreach(var horse in Horses)
            {
                horse.Plan = DataBaseConnection.GetNutritionPlansForHorse(horse.ID);
            }
            Horses = Horses;
        }
    }
}
