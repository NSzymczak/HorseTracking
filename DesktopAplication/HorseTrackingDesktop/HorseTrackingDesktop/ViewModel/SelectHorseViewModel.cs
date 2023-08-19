using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.Database.HorseService;
using HorseTrackingDesktop.Services.Database.NutritionService;
using HorseTrackingDesktop.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HorseTrackingDesktop.ViewModel
{
    public partial class SelectHorseViewModel : BaseViewModel
    {
        private readonly IHorseService _horseService;
        private readonly INutritionService _nutritionService;

        public bool isEdit = false;
        public string ButtonTitle;
        public SelectionMode SelectedType;
        public List<Horses> Horses { get; set; }
        public List<Horses> SelectedHorses { get; set; }
        public Horses SelectedHorse { get; set; }
        public NutritionPlans Plans { get; set; }

        public SelectHorseViewModel(IHorseService horseService, INutritionService nutritionService)
        {
            _horseService = horseService;
            _nutritionService = nutritionService;
        }

        public async Task SetUP()
        {
            Horses = await _horseService.GetHorses();
            SelectedType = isEdit ? SelectionMode.Single : SelectionMode.Multiple;
            OnPropertyChanged(nameof(SelectedType));
            OnPropertyChanged(nameof(Horses));
        }

        [RelayCommand]
        public async Task ButtonClick(Window window)
        {
            if (isEdit)
            {
                await EditPlan(window);
            }
            else
            {
                await AddPlan(window);
            }
            window.Close();
        }

        public async Task AddPlan(Window window)
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
        }

        public async Task EditPlan(Window window)
        {
            var nutritionPlan = (await _nutritionService.GetPlanForHorse(SelectedHorse.HorseId)).FirstOrDefault();
            if (nutritionPlan != null)
            {
                new AddNutritionView(nutritionPlan, SelectedHorse).ShowDialog();
            }
        }
    }
}