using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.Database.CompetitionService;
using HorseTrackingDesktop.View;
using HorseTrackingDesktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        [RelayCommand]
        public async Task AsignHorse(Contests contest)
        {
            var selectHorse = new SelectHorseView();
            selectHorse.ShowDialog();
            var horse = selectHorse?.viewModel?.SelectedHorse;
            if (horse == null)
            {
                return;
            }
            await _competitionService.AsignHorseForContest(horse.HorseId, contest.ContestId);
            await LoadContests(CurrentCompetition);
        }

        [RelayCommand]
        public async Task RemoveParticipation(Participations participation)
        {
            await _competitionService.RemoveParticipation(participation.ParticipationId);
            await Refresh();
        }

        [RelayCommand]
        public async Task AddCompetition()
        {
            new AddCompetitionView().ShowDialog();
            await Refresh();
        }

        [RelayCommand]
        public async Task EditCompetition()
        {
            new AddCompetitionView(CurrentCompetition).ShowDialog();
            await Refresh();
        }

        [RelayCommand]
        public async Task RemoveCompetition()
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć wybrane zawody?", "Uwaga", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                if (CurrentCompetition != null)
                {
                    await _competitionService.RemoveCompetition(CurrentCompetition.CompetitionId);
                }
                await Refresh();
            }
        }
    }
}