using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services.AppState;
using HorseTrackingMobile.Services.Database.CompetitionService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HorseTrackingMobile.ViewModels
{
    internal class CompetitionViewModel : BaseViewModel
    {
        private readonly ICompetitionService _competitionService;
        private readonly IAppState _appState;
        public ObservableCollection<Participation> Participation { get; set; }

        public CompetitionViewModel(ICompetitionService competitionService, IAppState appState)
        {
            _competitionService = competitionService;
            _appState = appState;
        }

        public void Load()
        {
            var list = _competitionService.GetParticipation(_appState.CurrentUser.Id);
            if (list != null)
            {
                Participation = new ObservableCollection<Participation>(list);
            }
            OnPropertyChanged(nameof(Participation));
        }
    }
}