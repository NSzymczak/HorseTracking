using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using HorseTrackingDesktop.Services.Database.HorseService;
using HorseTrackingDesktop.Services.Database.VisitService;
using HorseTrackingDesktop.View;
using HorseTrackingDesktop.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.PageModel
{
    public partial class VisitPageModel : BaseViewModel
    {
        private readonly IAppState _appState;
        private readonly IVisitService _visitService;
        private readonly IHorseService _horseService;

        public ObservableCollection<Visits>? Visits { get; set; }
        public ICollection<Horses>? Horses { get; set; }

        private Horses? currentHorse;

        public Horses? CurrentHorse
        {
            get { return currentHorse; }
            set
            {
                if (currentHorse != value)
                {
                    currentHorse = value;
                    OnPropertyChanged(nameof(CurrentHorse));
                }
            }
        }

        private Visits? selectedVisit;

        public Visits? SelectedVisit
        {
            get { return selectedVisit; }
            set
            {
                if (selectedVisit != value)
                {
                    selectedVisit = value;
                    OnPropertyChanged(nameof(CurrentHorse));
                }
            }
        }

        public VisitPageModel(IAppState appState, IVisitService visitService, IHorseService horseService)
        {
            _visitService = visitService;
            _appState = appState;
            _horseService = horseService;
        }

        public async Task SetUp()
        {
            if (_appState.CurrentUser == null)
            {
                return;
            }
            Horses = await _horseService.GetHorses();
            CurrentHorse = Horses.FirstOrDefault();
            if (CurrentHorse == null)
            {
                return;
            }
            await GetVisit(CurrentHorse.HorseId);
            OnPropertyChanged(nameof(Horses));
            OnPropertyChanged(nameof(CurrentHorse));
        }

        private async Task GetVisit(int id)
        {
            var visits = await _visitService.GetAllVisit(id);
            Visits = new ObservableCollection<Visits>(visits);
            OnPropertyChanged(nameof(Visits));
        }

        [RelayCommand]
        public async Task AddVisit(Visits visit)
        {
            new AddVisitView().ShowDialog();
            if (CurrentHorse != null)
                await GetVisit(CurrentHorse.HorseId);
        }

        [RelayCommand]
        public async Task RemoveVistit()
        {
            if (selectedVisit != null)
            {
                await _visitService.RemoveVisit(selectedVisit);
            }
        }

        [RelayCommand]
        public async Task EditVisit()
        {
            if (selectedVisit != null)
            {
                new AddVisitView(selectedVisit).ShowDialog();
                await GetVisit(selectedVisit.HorseId);
            }
        }

        public async Task SwitchHorse()
        {
            if (CurrentHorse == null)
            {
                return;
            }
            await GetVisit(CurrentHorse.HorseId);
        }

        public void GoToDetails()
        {
            if (selectedVisit != null)
            {
                new VisitDetailsView(selectedVisit).ShowDialog();
            }
        }
    }
}