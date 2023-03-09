using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Database;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.ViewModel;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Microsoft.EntityFrameworkCore;
using SkiaSharp;

namespace HorseTrackingDesktop.PageModel
{
    public partial class StatisticPageModel : BaseViewModel
    {
        public string Test { get; set; }
        List<Activity> activities = new List<Activity>();
        private static int[] chartData = new int[11];

        public ObservableCollection<ISeries> Series { get; set; }

        public StatisticPageModel()
        {
            activities = Activity.activities.ToList();

            Series = new ObservableCollection<ISeries>
            {
                new LineSeries<Activity>
                {
                    Values = activities,
                    Fill = null
                }
            };
        }


        [RelayCommand]
        public async void LoadData()
        {
            await GetDataFromDatabase.GetAllActivities();
            activities = Activity.activities.ToList();
        }

        //private async Task saj()
        //{
        //    chartData = new int[11];
        //    foreach (var activity in activities)
        //    {
        //        //chartData[activity.ActivityType]++;
        //    }
        //}

        //public ISeries[] Series { get; set; }
        //    = new ISeries[]
        //    {
        //        new PieSeries<int> { Values=new int[]{chartData[0]}, Name="Jazda" },
        //        new PieSeries<int> { Values=new int[]{chartData[1]}, Name="Spacer" },
        //        new PieSeries<int> { Values=new int[]{chartData[2]}, Name="Skoki" },
        //        new PieSeries<int> { Values=new int[]{chartData[3]}, Name="Lonża" },
        //        new PieSeries<int> { Values=new int[]{chartData[4]}, Name="Teren" },
        //        new PieSeries<int> { Values=new int[]{chartData[5]}, Name="Karuzela" },
        //        new PieSeries<int> { Values=new int[]{chartData[6]}, Name="Padok" },
        //        new PieSeries<int> { Values=new int[]{chartData[7]}, Name="Zawody" },
        //        new PieSeries<int> { Values=new int[]{chartData[8]}, Name="Kros"},
        //        new PieSeries<int> { Values=new int[]{chartData[9]}, Name="Ujeżdżenie" },
        //        new PieSeries<int> { Values=new int[]{chartData[10]}, Name="Skoki luzem" }
        //    };
    }

}
