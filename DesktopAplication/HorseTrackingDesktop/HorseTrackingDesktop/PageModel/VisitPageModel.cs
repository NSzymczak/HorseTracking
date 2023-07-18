using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using HorseTrackingDesktop.Services.Database.VisitService;
using HorseTrackingDesktop.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;

namespace HorseTrackingDesktop.PageModel
{
    public class VisitPageModel : BaseViewModel
    {
        private readonly IAppState _appState;
        private readonly IVisitService _visitService;
        public List<Visits>? Visits { get; set; }
        public ICollection<Horses>? Horses { get; set; }

        public Horses? CurrentHorse { get; set; }

        public VisitPageModel(IAppState appState ,IVisitService visitService)
        {
            _visitService = visitService;
            _appState = appState;
            Visits = _visitService.GetAllVisit(1).Result;
            Horses = _appState.CurrentUser?.Horses;
            CurrentHorse = Horses?.FirstOrDefault();
        }
    }
}
