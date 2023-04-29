using HorseTrackingMobile.Database;
using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services;
using HorseTrackingMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HorseTrackingMobile.ViewModels
{
    public class ActivityViewModel : HorseAppViewModel
    {
        public ObservableCollection<DayOfActivity> DayOfActivities { get; set; } = new ObservableCollection<DayOfActivity>();
        public DateTime MainDate { get; set; }

        public ICommand LoadHorsesCommand { get; set; }
        public ICommand PrevCommand { get; set; }
        public ICommand NextCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand ChangeHorse { get; set; }
        public ICommand ActivityTapped { get; set; }

        public ActivityViewModel()
        {
            SetMainDate();
            PrevCommand = new Command(() =>
            {
                MainDate = MainDate.AddDays(-7);
                ChangeWeek();
            });
            NextCommand = new Command(() =>
            {
                MainDate = MainDate.AddDays(7);
                ChangeWeek();
            });
            SwitchHorseCommand = new Command(() =>
            {
                Horse.CurrentHorse = CurrentHorse;
                LoadActivityUI();
            });
            ActivityTapped = new Command<Activity>(async(activity) =>
            {
                if (activity == null)
                    return;

                await Shell.Current.GoToAsync($"{nameof(ActivityDetailsView)}?{nameof(ActivityDetailsViewModel.ActivityID)}={activity.ID}");
            });
            AddCommand = new Command(async() =>
            {
                await Shell.Current.GoToAsync(nameof(AddActivityView));
            });

        }

        public void Load()
        {
            CurrentHorse = Horse.CurrentHorse;
            LoadActivityUI();
        }

        private void SetMainDate()
        {
            var date = DateTime.Now.Date;
            var dayOfWeek = date.Date.DayOfWeek == 0 ? 6 : Convert.ToInt32(date.Date.DayOfWeek) - 1;
            MainDate = date.AddDays(-dayOfWeek).Date;
        }

        #region Load activity
        private void ChangeWeek()
        {
            ClearView();
            LoadActivityUI();
            OnPropertyChanged(nameof(DayOfActivities));
        }

        private void LoadActivityUI()
        {
            if (!ListServices.IsAny(DayOfActivities))
            {
                DayOfActivities.Clear();
            }

            AddList();
            AsignActivityToDays();
        }

        private void AddList()
        {
            for (int i = 0; i < 7; i++)
            {
                var date = MainDate.AddDays(i);
                var dayOfActivity = new DayOfActivity()
                {
                    DateTime = date,
                    DayOfWeek = date.DayOfWeek,
                    Label = $"{Dictionaries.DayOfWeek.ElementAt(i).Value} {date:dd.MM.yyyy}",
                    ListOfActivity = new ObservableCollection<Activity>()
                };
                DayOfActivities.Add(dayOfActivity);
            }
        }

        private void AsignActivityToDays()
        {
            if (CurrentHorse == null)
                return;
            if (ListServices.IsAny(CurrentHorse.ListOfAllActivityForHorse))
            {
                CurrentHorse.ListOfAllActivityForHorse = DataBaseConnection.GetActivity(CurrentHorse.ID);
            }
            var activityForWeek = CurrentHorse.ListOfAllActivityForHorse.Where(x => x.Date >= MainDate && x.Date <= MainDate.AddDays(7)).ToList();

            foreach (var activity in activityForWeek)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (DayOfActivities[i].DayOfWeek == activity.Date.DayOfWeek)
                    {
                        DayOfActivities[i].ListOfActivity.Add(activity);
                    }
                }
            }
        }

        #endregion

        private void ClearView()
        {
            DayOfActivities.Clear();
        }

    }
}
