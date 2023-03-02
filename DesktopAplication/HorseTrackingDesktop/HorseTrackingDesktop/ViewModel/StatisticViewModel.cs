using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Database;
using HorseTrackingDesktop.Models;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Microsoft.EntityFrameworkCore;

namespace HorseTrackingDesktop.ViewModel
{
    public partial class StatisticViewModel : BaseViewModel
    {
        public string Test { get; set; }
        List<Activity> activities= new List<Activity>();

        [RelayCommand]
        public async void LoadData()
        {
            await GetDataFromDatabase.GetAllActivities();
            activities = Activity.activities.ToList();
        }



        public ISeries[] Series { get; set; }
            = new ISeries[]
            {
                new PieSeries<int> { Values=new int[]{1}, Name="Padok" },
                new PieSeries<int> { Values=new int[]{1}, Name="Jazda"}
            };
    }

}
