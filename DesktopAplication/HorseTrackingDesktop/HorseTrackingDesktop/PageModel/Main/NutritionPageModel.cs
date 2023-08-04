using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using HorseTrackingDesktop.Services.Database.HorseService;
using HorseTrackingDesktop.Services.Database.NutritionService;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.PageModel.Main
{
    internal class NutritionPageModel
    {
        private readonly INutritionService _nutritionService;
        private readonly IAppState _appState;
        private readonly IHorseService _horseService;

        public List<NutritionPlans>? NutritionPlans { get; set; }

        public NutritionPageModel(INutritionService nutritionService, IAppState appState,
                                  IHorseService horseService)
        {
            _nutritionService = nutritionService;
            _appState = appState;
            _horseService = horseService;
        }

        public async Task GetPlans()
        {
            var horse = await _horseService.GetHorses();
            var d = await _nutritionService.GetPlanForHorse(horse.First().HorseId);
            NutritionPlans = d.ToList();
        }
    }
}