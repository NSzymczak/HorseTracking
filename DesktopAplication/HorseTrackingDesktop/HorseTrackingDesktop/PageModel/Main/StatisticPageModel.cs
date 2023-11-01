using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using HorseTrackingDesktop.Services.Database.CompetitionService;
using HorseTrackingDesktop.Services.Database.HorseService;
using HorseTrackingDesktop.ViewModel;
using LiveChartsCore;
using LiveChartsCore.Drawing;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.PageModel
{
    public partial class StatisticPageModel : BaseViewModel
    {
        private readonly IAppState _appState;
        private readonly IHorseService _horseService;
        private readonly ICompetitionService _competitionService;

        private List<Activities> activities = new List<Activities>();

        public List<Horses> Horses { get; set; }
        private Horses _currentHorse;

        public Horses CurrentHorse
        {
            get { return _currentHorse; }
            set
            {
                _currentHorse = value;
                _ = GetActivityTypeChartForHorse(CurrentHorse);
                _ = GetCompetitionTypeChartForHorse(CurrentHorse);
            }
        }

        public ObservableCollection<ISeries> ChartOneHorseActivity { get; set; } = new ObservableCollection<ISeries>();
        public ObservableCollection<ISeries> ChartAllHorsesActivity { get; set; } = new ObservableCollection<ISeries>();
        public ObservableCollection<ISeries> ChartOneHorseCompetition { get; set; } = new ObservableCollection<ISeries>();
        public ObservableCollection<ISeries> ChartAllHorsesCompetition { get; set; } = new ObservableCollection<ISeries>();

        public StatisticPageModel(IAppState appState, IHorseService horseService, ICompetitionService competitionService)
        {
            _appState = appState;
            _horseService = horseService;
            _competitionService = competitionService;
        }

        public async Task Load()
        {
            Horses = new List<Horses>(_appState.CurrentUser.Horses);
            if (Horses?.Count == 0)
                return;
            CurrentHorse = Horses[0];

            await GetActivityTypeChartForHorse(CurrentHorse);
            await GetActivityTypeChartForAllHorses();
            await GetCompetitionTypeChartForHorse(CurrentHorse);
            await GetComprtitionTypeChartForAllHorses();

            OnPropertyChanged(nameof(CurrentHorse));
            OnPropertyChanged(nameof(Horses));
        }

        public async Task GetActivityTypeChartForHorse(Horses horses)
        {
            var data = (await _horseService.GetHorseActivity(horses.HorseId))
                .Where(x => x.Date > DateTime.Now.AddDays(-300))
                .GroupBy(x => x.ActivityType);
            if (data != null)
                MakeChart(data, ChartOneHorseActivity);
        }

        private async Task GetActivityTypeChartForAllHorses()
        {
            var activities = new List<Activities>();
            foreach (var horses in Horses)
            {
                var horsesAct = await _horseService.GetHorseActivity(horses.HorseId);
                foreach (var activity in horsesAct)
                {
                    activities.Add(activity);
                }
            }
            var data = activities.Where(x => x.Date > DateTime.Now.AddDays(-300)).GroupBy(x => x.ActivityType);
            if (data != null)
                MakeChart(data, ChartAllHorsesActivity);
        }

        private async Task GetComprtitionTypeChartForAllHorses()
        {
            var participations = new List<Participations>();
            foreach (var horses in Horses)
            {
                var horsesAct = await _competitionService.GetHorseParticipation(horses.HorseId);
                foreach (var part in horsesAct)
                {
                    participations.Add(part);
                }
            }
            var data = participations.GroupBy(x => x.Place);
            if (data != null)
                MakeChart(data, ChartAllHorsesCompetition);
        }

        public async Task GetCompetitionTypeChartForHorse(Horses horses)
        {
            var data = (await _competitionService.GetHorseParticipation(horses.HorseId))
                .GroupBy(x => x.Place);
            if (data != null)
                MakeChart(data, ChartOneHorseCompetition);
        }

        private void MakeChart(IEnumerable<IGrouping<int, Activities>> data, ObservableCollection<ISeries> series)
        {
            series.Clear();
            foreach (var element in data)
            {
                if (ActivityType.ActivityTypeIdMap.TryGetValue(element.Key, out var activity))
                    series.Add(new PieSeries<int>
                    {
                        Values = new int[] { element.Count() },
                        Name = activity.Name,
                        Fill = new SolidColorPaint(new SKColor(activity.Color.R, activity.Color.G, activity.Color.B, activity.Color.A))
                    });
            }
        }

        private void MakeChart(IEnumerable<IGrouping<int?, Participations>> data, ObservableCollection<ISeries> series)
        {
            series.Clear();
            foreach (var element in data)
            {
                series.Add(new PieSeries<int>
                {
                    Values = new int[] { element.Count() },
                    Name = "Miejsce " + element.FirstOrDefault()?.Place.ToString() + ": "
                });
            }
        }
    }
}