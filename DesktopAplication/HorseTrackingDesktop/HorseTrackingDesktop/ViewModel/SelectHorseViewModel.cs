using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Enumerable;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.Database.CompetitionService;
using HorseTrackingDesktop.Services.Database.HorseService;
using HorseTrackingDesktop.Services.Database.NutritionService;
using HorseTrackingDesktop.View;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HorseTrackingDesktop.ViewModel
{
    public partial class SelectHorseViewModel : BaseViewModel
    {
        private readonly IHorseService _horseService;
        private readonly INutritionService _nutritionService;
        private readonly ICompetitionService _competitionService;

        public PageName pageFrom;
        public string ButtonTitle;
        public SelectionMode SelectedType;
        public List<Horses> Horses { get; set; }
        public List<Horses> SelectedHorses { get; set; }
        public Horses SelectedHorse { get; set; }
        public NutritionPlans Plans { get; set; }

        public SelectHorseViewModel(IHorseService horseService, INutritionService nutritionService,
                                    ICompetitionService competitionService)
        {
            _horseService = horseService;
            _nutritionService = nutritionService;
            _competitionService = competitionService;
        }

        public async Task SetUP()
        {
            Horses = await _horseService.GetHorses();
            SelectedType = pageFrom == PageName.NutritionAdd ? SelectionMode.Multiple : SelectionMode.Single;
            OnPropertyChanged(nameof(SelectedType));
            OnPropertyChanged(nameof(Horses));
        }

        [RelayCommand]
        public void ButtonClick(Window window)
        {
            window.Close();
        }
    }
}