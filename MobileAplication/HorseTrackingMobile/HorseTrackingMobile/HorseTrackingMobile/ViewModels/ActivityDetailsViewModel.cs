using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services;
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

    public class ActivityDetailsViewModel : HorseAppViewModel
    {
        public Command AddActivityCommand { get; set; }

        public ActivityDetailsViewModel()
        {
            AddActivityCommand = new Command(Add);
            SetDate();
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

        private void SetDate()
        {
            Date= DateTime.Now;
        }

        private async void LoadActivityId(int activityId)
        {
            try
            {
                var item = Horse.CurrentHorse.ListOfAllActivityForHorse.Select(x => x).Where(x => x.ID == activityId).FirstOrDefault();
                if (item == null) return;
                var activity = item;
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

        private void Add()
        {
            try
            {
                var add = new Activity()
                {
                    ID = ListServices.IsAny(Horse.CurrentHorse.ListOfAllActivityForHorse) ? 1 : Horse.CurrentHorse.ListOfAllActivityForHorse.Max(x => x.ID) + 1,
                    Date = Date,
                    Time = Time,
                    Type = Type,
                    Trainer = Trainer,
                    Satisfaction = Satisfaction,
                    Intensivity = Intensivity,
                    Description = Description
                };

                Horse.CurrentHorse.ListOfAllActivityForHorse.Add(add);
                Shell.Current.GoToAsync("..");

            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Błąd", "Coś poszło nie tak, nie udało się dodać aktywności", "Dobrze");
                Shell.Current.GoToAsync("..");
            }
        }
    }
}
