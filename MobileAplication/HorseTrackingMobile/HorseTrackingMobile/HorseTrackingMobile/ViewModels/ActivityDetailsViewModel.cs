using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services;
using HorseTrackingMobile.Services.AppState;
using HorseTrackingMobile.Services.Database.ActivityServices;
using HorseTrackingMobile.Services.Database.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HorseTrackingMobile.ViewModels
{
    [QueryProperty(nameof(ActivityID), nameof(ActivityID))]

    public class ActivityDetailsViewModel : BaseViewModel
    {

        private readonly IAppState _appState;
        private readonly IActivityService _activityService;
        private readonly IUserService _userService;
        private readonly IAppShellRoutingService _appShellRoutingService;

        public ICommand AddActivityCommand { get; set; }
        public ICommand EditActivityCommand { get; set; }
        public ICommand DeleteActivityCommand { get; set; }

        public bool CanModifyData => _appState.CurrentUser.Type.Type == "horseOwner";
        public static bool isEdit = false;

        public ActivityDetailsViewModel(IAppState appState, IActivityService activityService, IUserService userService, IAppShellRoutingService appShellRoutingService)
        {
            _appState = appState;
            _activityService = activityService;
            _userService = userService;
            _appShellRoutingService = appShellRoutingService;

            EditActivityCommand = new Command(() =>
            {
                var activity = new Activity()
                {
                    ID = ActivityID,
                    Date = Date,
                    Time = Time,
                    Type = Type,
                    Trainer = Trainer,
                    Satisfaction = Satisfaction,
                    Intensivity = Intensivity,
                    Description = Description,
                    User = _appState.CurrentUser,
                    Horse = _appState.CurrentHorse
                };
                isEdit = true;
                _appShellRoutingService.GoToAddActivity(activity);
            });
            DeleteActivityCommand = new Command(() =>
            {
                _activityService.DeleteActivity(ActivityID);
                Shell.Current.GoToAsync("..");
            });
            AddActivityCommand = new Command(() =>
            {
                try
                {
                    var activity = new Activity()
                    {
                        Date = Date,
                        Time = Time,
                        Type = Type,
                        Trainer = Trainer,
                        Satisfaction = Satisfaction,
                        Intensivity = Intensivity,
                        Description = Description,
                        User = _appState.CurrentUser,
                        Horse = _appState.CurrentHorse
                    };
                    if(isEdit) 
                    {
                        EditActivity(activity, ActivityID);
                    }
                    else
                    {
                        AddActivity(activity);
                    }

                    isEdit = false;
                    Shell.Current.Navigation.PopToRootAsync();
                }
                catch (Exception ex)
                {
#if DEBUG

                    App.Current.MainPage.DisplayAlert("Błąd", ex.Message, "dupa");
#endif
                    App.Current.MainPage.DisplayAlert("Błąd", $"Coś poszło nie tak, nie udało się {(isEdit? "dodać": "edytować")} aktywności", "Dobrze");
                    Shell.Current.GoToAsync("..");
                }
            });
            SetDate();
        }

        private void AddActivity(Activity activity)
        {
            _activityService.AddActivity(activity);
            _appState.CurrentHorse.ListOfAllActivity.Add(activity);
        }

        private void EditActivity(Activity activity, int id)
        {
            _activityService.EditActivity(id, activity);
            _appState.CurrentHorse.ListOfAllActivity.Add(activity);
        }

        private void CheckActivityType()
        {
            if (ActivityType.IsActiveActivity(activityType))
                IsActiveActivity = true;
            else
            {
                IsActiveActivity = false;
            }
            OnPropertyChanged(nameof(IsActiveActivity));
        }

        public bool IsActiveActivity { get; set; }

        public List<ActivityType> ListOfActivityType
        {
            get => ActivityType.ListOfActivity;
        }

        int activityID;
        public int ActivityID
        {
            get
            {
                return activityID;
            }
            set
            {
                activityID = value;
                LoadActivityId(value);
            }
        }

        private ActivityType activityType;
        public ActivityType Type
        {
            get => activityType;
            set
            {
                SetProperty(ref activityType, value);
                CheckActivityType();
            }
        }

        private DateTime activityDate;
        public DateTime Date
        {
            get => activityDate;
            set => SetProperty(ref activityDate, value);
        }

        private int satisfaction;
        public int Satisfaction
        {
            get => satisfaction;
            set => SetProperty(ref satisfaction, value);
        }

        private int intensivity;
        public int Intensivity
        {
            get => intensivity;
            set => SetProperty(ref intensivity, value);
        }

        private int time;
        public int Time
        {
            get => time;
            set => SetProperty(ref time, value);
        }
        public List<User> ListOfTrainers
        {
            get => _appState.ListOfTrainer;
        }

        private User trainer;
        public User Trainer
        {
            get => trainer;
            set => SetProperty(ref trainer, value);
        }
        private string description;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        private void SetDate()
        {
            Date = DateTime.Now;
        }

        private async void LoadActivityId(int activityId)
        {
            try
            {
                var item = _appState.CurrentHorse.ListOfAllActivity.Select(x => x).Where(x => x.ID == activityId).FirstOrDefault();
                if (item == null) return;
                Date = item.Date;
                Time = item.Time;
                Type = item.Type;
                Trainer = item.Trainer;
                Satisfaction = item.Satisfaction;
                Intensivity = item.Intensivity;
                Description = item.Description;
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Błąd", "Coś poszło nie tak, nie udało się wczytać szczegółów", "Dobrze");
            }
        }

    }
}
