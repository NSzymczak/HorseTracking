using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using HorseTrackingDesktop.ViewModel;
using System.Collections.Generic;
using System.Windows.Documents;

namespace HorseTrackingDesktop.PageModel.Main
{
    public class AcountPageModel : BaseViewModel
    {
        private readonly IAppState _appState;
        public UserAcounts User { get; set; }
        public List<Horses> UserHorses { get; set; }

        public AcountPageModel(IAppState appState)
        {
            _appState = appState;

            User = _appState.CurrentUser;
            UserHorses = new List<Horses>(_appState.CurrentUser.Horses);
            OnPropertyChanged(nameof(UserHorses));
        }
    }
}