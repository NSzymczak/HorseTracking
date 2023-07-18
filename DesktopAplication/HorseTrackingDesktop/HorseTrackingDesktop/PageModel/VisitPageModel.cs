using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using HorseTrackingDesktop.Services.Database.VisitService;
using HorseTrackingDesktop.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace HorseTrackingDesktop.PageModel
{
    public class VisitPageModel : BaseViewModel
    {
        private readonly IAppState _appState;
        private readonly IVisitService _visitService;

        public List<Visits>? Visits { get; set; }
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
        public VisitPageModel(IAppState appState ,IVisitService visitService)
        {
            _visitService = visitService;
            _appState = appState;
        }

        public async Task SetUp()
        {
            if (_appState.CurrentUser == null)
            {
                return;
            }
            Horses = _appState.CurrentUser.Horses;
            CurrentHorse = Horses.FirstOrDefault();
            if(CurrentHorse == null)
            {
                return;
            }
            await GetVisit(CurrentHorse.HorseId);
            OnPropertyChanged(nameof(Horses));
            OnPropertyChanged(nameof(CurrentHorse));
        }

        private async Task GetVisit(int id)
        {
            Visits = await _visitService.GetAllVisit(id);
            OnPropertyChanged(nameof(Visits));
        }

        public async Task SwitchHorse()
        {
            if(CurrentHorse== null)
            {
                return;
            }
            await GetVisit(CurrentHorse.HorseId);
        }
    }
}
