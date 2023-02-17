using HorseTrackingMobile.Database;
using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace HorseTrackingMobile.ViewModels
{
    public class ActivityViewModel : BaseViewModel
    {
        public List<DayOfActivity> DayOfActivities { get; set; } = new List<DayOfActivity>();


        public DateTime MainDate { get; set; }

        public List<Activity> Activity { get; set; }


        Dictionary<int, string> DayOfWeek = new Dictionary<int, string>()
        {
            {1,"Poniedziałek"},
            {2, "Wtorek"},
            {3, "Środa"},
            {4, "Czwartek"},
            {5, "Piątek"},
            {6, "Sobota"},
            {7, "Niedziela"}
        };

        public void Load()
        {
            SetMainDate();
            AddList();
            AsignActivity();
        }

        public void SetMainDate()
        {
            var date = DateTime.Now.Date;
            var dayOfWeek = date.Date.DayOfWeek == 0 ? 6 : Convert.ToInt32(date.Date.DayOfWeek) - 1;
            MainDate = date.AddDays(-dayOfWeek).Date;
        }

        public void AddList()
        {
            for (int i = 0; i < 7; i++)
            {
                var date = MainDate.AddDays(i);
                var dayOfActivity = new DayOfActivity()
                {
                    DateTime = date,
                    DayOfWeek = date.DayOfWeek,
                    Label = $"{DayOfWeek.ElementAt(i).Value} {date.ToString("dd.MM.yyyy")}",
                    ListOfActivity=new List<Activity>()
                };
                DayOfActivities.Add(dayOfActivity);
            }
        }

        public void AsignActivity()
        {
            Activity = TemporaryAdding.AddActivity();
           foreach(var activity in Activity)
           {
                for (int i = 0; i < 7; i++)
                {
                    if (DayOfActivities[i].DayOfWeek == activity.Date.DayOfWeek)
                    {
                        DayOfActivities[i].ListOfActivity.Add(activity);
                    }
                }
           }
            DayOfActivities = DayOfActivities;
        }
    }
}
