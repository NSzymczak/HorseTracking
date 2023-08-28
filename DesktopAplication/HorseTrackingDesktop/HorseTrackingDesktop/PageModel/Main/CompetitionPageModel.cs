using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.Database.CompetitionService;
using HorseTrackingDesktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.PageModel.Main
{
    public partial class CompetitionPageModel : BaseViewModel
    {
        private readonly ICompetitionService _competitionService;
        public List<Competitions>? Competitions { get; set; }
        public List<Contests>? Contests { get; set; }

        public Competitions CurrentCompetition { get; set; }

        public CompetitionPageModel(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        public async Task Load()
        {
            await Refresh();
        }

        public async Task Refresh()
        {
            Competitions = await _competitionService.GetCompetitions();
            OnPropertyChanged(nameof(Competitions));
        }

        [RelayCommand]
        public async Task LoadContests(Competitions competitions)
        {
            CurrentCompetition = competitions;
            var contestList = await _competitionService.GetContestsForCompetition(competitions.CompetitionId);
            if (contestList != null)
            {
                Contests = contestList;
                OnPropertyChanged(nameof(Contests));
            }
        }

        public async Task AddCompetition()
        {
        }

        public async Task EditCompetition()
        {
        }

        public async Task RemoveCompetition()
        {
            if (CurrentCompetition != null)
            {
                await _competitionService.RemoveCompetition(CurrentCompetition.CompetitionId);
            }
            await Refresh();
        }
    }
}