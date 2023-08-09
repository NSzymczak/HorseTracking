using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.Database.HorseService;
using HorseTrackingDesktop.Services.Database.NutritionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HorseTrackingDesktop.ViewModel
{
    public partial class AddPlanForHorseViewModel : BaseViewModel
    {
        private readonly IHorseService _horseService;
        private readonly INutritionService _nutritionService;
        public List<Horses> Horses { get; set; }
        public List<Horses> SelectedHorses { get; set; }
        public NutritionPlans Plans { get; set; }

        public AddPlanForHorseViewModel(IHorseService horseService, INutritionService nutritionService)
        {
            _horseService = horseService;
            _nutritionService = nutritionService;
        }

        public async Task SetUP()
        {
            Horses = await _horseService.GetHorses();
            OnPropertyChanged(nameof(Horses));
        }

        [RelayCommand]
        public async Task AddPlanForHorse(Window window)
        {
            foreach (var horse in SelectedHorses)
            {
                var hasDiet = await _nutritionService.HorseHasDiet(horse);
                if (hasDiet)
                {
                    var result = MessageBox.Show("Ten koń ma już ustaloną dietę. Czy chesz zmienić jego dietę?", "Uwaga", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        await _nutritionService.ChangeDiet(horse, Plans);
                    }
                }
                else
                {
                    await _nutritionService.ChangeDiet(horse, Plans);
                }
            }
            window.Close();
        }
    }
}