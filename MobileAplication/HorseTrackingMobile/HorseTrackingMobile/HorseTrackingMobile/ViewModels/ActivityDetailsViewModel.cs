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
                var item = ListOfActivity.Select(x=>x).Where(x => x.ID == activityId).FirstOrDefault();
                if (item == null) return;
                var activity = item;
                Date = item.Date;
                Time = item.Time;
                Type = item.Type;
                Trainer= item.Trainer;
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
                var item = ListOfActivity.Select(x => x).Where(x => x.ID == ActivityID).FirstOrDefault();
                ListOfActivity.Remove(item);
                item.ID = ActivityID;
                item.Date = Date;
                item.Time = Time;
                item.Type = Type;
                item.Trainer = Trainer;
                item.Satisfaction = Satisfaction;
                item.Intensivity = Intensivity;
                item.Description = Description;
                ListOfActivity.Add(item);
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
