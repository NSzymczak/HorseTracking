using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services;
using HorseTrackingMobile.Services.Database.ActivityServices;
using HorseTrackingMobile.Services.Database.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace HorseTrackingMobile.ViewModels
{
    [QueryProperty(nameof(ActivityID), nameof(ActivityID))]

    public class ActivityDetailsViewModel : BaseViewModel
    {
        public ICommand AddActivityCommand { get; set; }
        private readonly IAppState _appState;
        private readonly IActivityService _activityService;
        private readonly IUserService _userService;
        public ActivityDetailsViewModel(IAppState appState, IActivityService activityService, IUserService userService)
        {
            _appState = appState;
            _activityService = activityService;
            _userService = userService;

            AddActivityCommand = new Command(() =>
            {
                try
                {
                    var activity = new Activity()
                    {
                        ID = ListServices.IsAny(_appState.CurrentHorse.ListOfAllActivity) ? 1 : _appState.CurrentHorse.ListOfAllActivity.Max(x => x.ID) + 1,
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

                    _activityService.AddActivity(activity);
                    _appState.CurrentHorse.ListOfAllActivity.Add(activity);
                    Shell.Current.GoToAsync("..");

                }
                catch
                {
                    App.Current.MainPage.DisplayAlert("Błąd", "Coś poszło nie tak, nie udało się dodać aktywności", "Dobrze");
                    Shell.Current.GoToAsync("..");
                }
            });
            SetDate();
        }

        private void CheckActivityType()
        {
            if (activityType == ActivityType.Ride ||
                activityType == ActivityType.Jump ||
                activityType == ActivityType.Competition ||
                activityType == ActivityType.Cross ||
                activityType == ActivityType.Dressage)
                IsActiveActivity= true;
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
            get => _userService.GetTrainers();
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
            Date= DateTime.Now;
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
