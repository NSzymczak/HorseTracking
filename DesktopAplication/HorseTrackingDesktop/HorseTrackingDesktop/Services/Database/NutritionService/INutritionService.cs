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
    }
}