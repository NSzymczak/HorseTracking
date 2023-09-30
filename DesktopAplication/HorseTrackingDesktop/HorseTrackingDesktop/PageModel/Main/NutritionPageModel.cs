using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using HorseTrackingDesktop.Services.Database.HorseService;
using HorseTrackingDesktop.Services.Database.NutritionService;
using HorseTrackingDesktop.View;
using HorseTrackingDesktop.ViewModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.PageModel.Main
{
    internal partial class NutritionPageModel : BaseViewModel
    {
        private readonly INutritionService _nutritionService;
        private readonly IAppState _appState;
        private readonly IHorseService _horseService;

        public ObservableCollection<NutritionPlans>? NutritionPlans { get; set; }

        public NutritionPageModel(INutritionService nutritionService, IAppState appState,
                                  IHorseService horseService) : base(appState)
        {
            _nutritionService = nutritionService;
            _appState = appState;
            _horseService = horseService;
        }

        public async Task GetPlans()
        {
            var horse = await _horseService.GetHorses();
            var horsesID = horse.Select(h => h.HorseId).ToArray();
            NutritionPlans = new ObservableCollection<NutritionPlans>(await _nutritionService.GetPlanForHorses(horsesID));
            OnPropertyChanged(nameof(NutritionPlans));
        }

        [RelayCommand]
        public async Task GoToAddPlan()
        {
            new AddNutritionView().ShowDialog();
            await GetPlans();
        }

        [RelayCommand]
        public async Task EditPlan()
        {
            var selectHorse = new SelectHorseView();
            selectHorse.ShowDialog();
            var horse = selectHorse?.viewModel?.SelectedHorse;
            if (horse == null)
            {
                return;
            }
            var nutritionPlan = (await _nutritionService.GetPlanForHorse(horse.HorseId)).FirstOrDefault();
            if (nutritionPlan != null)
            {
                new AddNutritionView(nutritionPlan, horse).ShowDialog();
            }
            await GetPlans();
        }
    }
}