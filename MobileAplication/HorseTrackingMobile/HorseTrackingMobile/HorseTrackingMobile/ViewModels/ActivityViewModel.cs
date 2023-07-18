using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services;
using HorseTrackingMobile.Services.AppState;
using HorseTrackingMobile.Services.Database.ActivityServices;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace HorseTrackingMobile.ViewModels
{
    public class ActivityViewModel : BaseViewModel
    {

        private readonly IActivityService _activityServices;
        private readonly IAppShellRoutingService _appShellRoutingService;
        private readonly IAppState _appState;

        public ICommand PrevCommand { get; set; }
        public ICommand NextCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand ChangeHorse { get; set; }
        public ICommand ActivityTapped { get; set; }
        public ICommand SwitchHorseCommand { get; set; }

        public DateTime MainDate { get; set; }
        public bool CanModifyData => _appState.CurrentUser.Type.Type == "horseOwner";
        public ObservableCollection<DayOfActivity> DayOfActivities { get; set; } = new ObservableCollection<DayOfActivity>();
        public ObservableCollection<Horse> Horses { get; set; }

        private Horse currentHorse;
        public Horse CurrentHorse
        {
            get { return currentHorse; }
            set
            {
                if (currentHorse != value)
                {
                    currentHorse = value;
                    OnPropertyChanged(nameof(CurrentHorse));
                }
            }
        }

        public ActivityViewModel( IActivityService activityServices, IAppShellRoutingService appShellRoutingService, 
                                  IAppState appState)
        {
            _activityServices = activityServices;
            _appShellRoutingService = appShellRoutingService;
            _appState = appState;

            Horses = new ObservableCollection<Horse>(_appState.HorseList);

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
                _appState.CurrentHorse = CurrentHorse;
                LoadActivityUI();
            });
            ActivityTapped = new Command<Activity>((activity) =>
            {
                if (activity == null)
                    return;
                _appShellRoutingService.GoToActivityDetails(activity);
            });
            AddCommand = new Command(() =>
            {
                _appShellRoutingService.GoToAddActivity();
            });
        }

        public void Load()
        {
            CurrentHorse = _appState.CurrentHorse;
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
            DayOfActivities.Clear();
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
        private void GetActivity()
        {
            try
            {
                CurrentHorse.ListOfAllActivity = _activityServices.GetActivities(CurrentHorse.ID);
            }
            catch (Exception ex)
            {
#if DEBUG

                App.Current.MainPage.DisplayAlert(ex.Message, ex.StackTrace,"dupa");
#endif
                App.Current.MainPage.DisplayAlert("Uwaga","Nie udało się pobrać aktywności z bazy danych","Dobrze");
                 
            }
        }

        private void AsignActivityToDays()
        {
            if (CurrentHorse == null)
                return;

            GetActivity();

            var activityForWeek = CurrentHorse.ListOfAllActivity.Where(x => x.Date >= MainDate && x.Date < MainDate.AddDays(7)).ToList();

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

    }
}
