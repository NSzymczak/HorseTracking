using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Database.NutritionServices
{
    public interface INutritionService
    {
        NutritionPlan GetNutritionPlan(int horseID);
        void GetUnitOfMeasure();
        void GetMealsName();
    }
}
