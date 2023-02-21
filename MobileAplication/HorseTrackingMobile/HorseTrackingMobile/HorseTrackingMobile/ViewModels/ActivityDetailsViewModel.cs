using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HorseTrackingMobile.ViewModels
{
    [QueryProperty(nameof(ActivityID), nameof(ActivityID))]

    public class ActivityDetailsViewModel : BaseViewModel
    {
        public Command AddActivityCommand{ get; set; }
        public List<Activity> activities;

        public ActivityDetailsViewModel()
        {
            AddActivityCommand = new Command(Add);
        }

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
            set => SetProperty(ref activityType, value);
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

        private async void LoadActivityId(int activityId)
        {
            try
            {
                var list = Activity.Activities;
                var item = Activity.Activities.Where(x => x.ID == activityId).FirstOrDefault();
                Date = item.Date;
                Time = item.Time;
                Type = item.Type;
                Trainer= item.Trainer;
                Satisfaction = item.Satisfaction;
                Intensivity = item.Intensivity;
                Description = item.Description;

            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Błąd", "Coś poszło nie tak, nie udało się wczytać szczegółów", "Dobrze");
            }
        }

        private void Add()
        {
            try
            {
                var activity = new Activity()
                {
                    ID = ActivityID,
                    Horse=Horse.CurrentHorse,
                    User=User.CurrentUser,
                    Date = Date,
                    Time = Time,
                    Type = Type,
                    Trainer= Trainer,
                    Satisfaction = Satisfaction,
                    Intensivity = Intensivity,
                    Description = Description
                };
                Activity.Activities.Add(activity);
                Shell.Current.GoToAsync("..");

            }
            catch (Exception)
            {
                App.Current.MainPage.DisplayAlert("Błąd", "Coś poszło nie tak, nie udało się dodać aktywności", "Dobrze");
                Shell.Current.GoToAsync("..");
            }
        }
    }
}
