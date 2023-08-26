using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
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
using System.Linq;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.PageModel
{
    public partial class StatisticPageModel : BaseViewModel
    {
        private readonly IAppState _appState;
        private readonly IHorseService _horseService;

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
            }
        }

        public List<ISeries> ChartOneHorse { get; set; } = new List<ISeries>();
        public List<ISeries> ChartAllHorses { get; set; } = new List<ISeries>();
        public List<ISeries> Series { get; set; } = new List<ISeries>();
        public List<ISeries> Series2 { get; set; } = new List<ISeries>();

        public StatisticPageModel(IAppState appState, IHorseService horseService)
        {
            _appState = appState;
            _horseService = horseService;
        }

        public async Task Load()
        {
            Horses = new List<Horses>(_appState.CurrentUser.Horses);
            if (Horses?.Count == 0)
                return;
            CurrentHorse = Horses[0];
            await GetActivityTypeChartForHorse(CurrentHorse);
            await GetActivityTypeChartForAllHorses();

            OnPropertyChanged(nameof(CurrentHorse));
            OnPropertyChanged(nameof(Horses));
        }

        public async Task GetActivityTypeChartForHorse(Horses horses)
        {
            var data = (await _horseService.GetHorseActivity(horses.HorseId))
                .Where(x => x.Date > DateTime.Now.AddDays(-300))
                .GroupBy(x => x.ActivityType);
            if (data != null)
                MakeChart(data, ChartOneHorse);
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
                MakeChart(data, ChartAllHorses);
        }

        private void MakeChart(IEnumerable<IGrouping<int, Activities>> data, List<ISeries> series)
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
            OnPropertyChanged(nameof(ChartOneHorse));
        }
    }
}