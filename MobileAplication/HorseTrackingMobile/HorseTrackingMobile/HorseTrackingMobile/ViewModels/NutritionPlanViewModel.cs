using HorseTrackingMobile.Database;
using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services.AppState;
using HorseTrackingMobile.Services.Database.NutritionServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms.Xaml;

namespace HorseTrackingMobile.ViewModels
{
    public class NutritionPlanViewModel : BaseViewModel
    {

        private readonly INutritionService _nutritionService;

        public ObservableCollection<Horse> Horses { get; set; }
        public Horse CurrentHorse { get; set; }


        public NutritionPlanViewModel(INutritionService nutritionService, IAppState appState)
        {
            _nutritionService = nutritionService;

            _nutritionService.GetUnitOfMeasure();
            _nutritionService.GetMealsName();

            Horses = new ObservableCollection<Horse>(appState.HorseList);
        }

        public void Load()
        {
            if (Horses == null)
            {
                return;
            }
            foreach (var horse in Horses)
            {
                horse.Plan = _nutritionService.GetNutritionPlan(horse.ID);
            }
        }
    }
}
