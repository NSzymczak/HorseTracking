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
using Xamarin.Forms;

namespace HorseTrackingMobile.ViewModels
{
    public class ActivityViewModel : BaseViewModel
    {

        public Command PrevCommand { get; set; }
        public Command NextCommand { get; set; }
        public Command AddCommand { get; set; }
        public Command ChangeHorse { get; set; }
        public Command SwitchHorseCommand { get; set; }
        public Command<Activity> ActivityTapped { get; set; }

        public ActivityViewModel()
        {
            PrevCommand = new Command(Prev);
            NextCommand = new Command(Next);
            ActivityTapped = new Command<Activity>(ActivitySelected);
            AddCommand = new Command(AddActivity);
            SwitchHorseCommand = new Command(SwitchHorse);
        }
        public ObservableCollection<DayOfActivity> DayOfActivities { get; set; } = new ObservableCollection<DayOfActivity>();
        public ObservableCollection<Horse> Horses { get; set; } = new ObservableCollection<Horse>();


        public DateTime MainDate { get; set; }



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
            DataBaseConnection.Connect();
            LoadHorses();
            SetMainDate();
            LoadActivityUI();
        }

        private void SwitchHorse()
        {
            ListOfActivity.Clear();
            LoadActivityUI();
        }

        private void LoadActivityUI()
        {
            if (!ListServices.IsAny(DayOfActivities))
            {
                DayOfActivities.Clear();
                ListOfActivity.Clear();
            }

            AddList();
            AsignActivityToDays();
        }

        private void LoadHorses()
        {
            var horseslist = DataBaseConnection.GetHorses(); //pobranie koni
            Horses.Clear();
            OnPropertyChanged(nameof(CurrentHorse));
            foreach (var h in horseslist)
            {
                Horses.Add(h);
            }
            CurrentHorse = horseslist.FirstOrDefault();
            OnPropertyChanged(nameof(CurrentHorse));
        }


        #region Load activity
        private void SetMainDate()
        {
            var date = DateTime.Now.Date;
            var dayOfWeek = date.Date.DayOfWeek == 0 ? 6 : Convert.ToInt32(date.Date.DayOfWeek) - 1;
            MainDate = date.AddDays(-dayOfWeek).Date;
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
                    Label = $"{DayOfWeek.ElementAt(i).Value} {date.ToString("dd.MM.yyyy")}",
                    ListOfActivity = new ObservableCollection<Activity>()
                };
                DayOfActivities.Add(dayOfActivity);
            }
        }

        private void AsignActivityToDays()
        {
            if (ListServices.IsAny(ListOfActivity))
            {
                ListOfActivity = DataBaseConnection.GetActivity(CurrentHorse.ID);
            }
            ListOfActivity = ListOfActivity.Where(x => x.Date >= MainDate && x.Date <= MainDate.AddDays(7)).ToList();
            foreach (var activity in ListOfActivity)
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


        private async void ActivitySelected(Activity activity)
        {
            if (activity == null)
                return;

            // This will push the ActivityDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ActivityDetailsView)}?{nameof(ActivityDetailsViewModel.ActivityID)}={activity.ID}");
        }

        private async void AddActivity()
        {
            var ID = ListOfActivity.Count + 1;
            var activity = new Activity()
            {
                ID = ID,
                Horse = CurrentHorse,
                User = CurrentUser,
                Date = DateTime.Now,
            };
            ListOfActivity.Add(activity);
            await Shell.Current.GoToAsync($"{nameof(AddActivityView)}?{nameof(ActivityDetailsViewModel.ActivityID)}");
        }

        private void ClearView()
        {
            DayOfActivities.Clear();
        }

        #region Navigation between weeks
        private void Prev()
        {
            MainDate = MainDate.AddDays(-7);
            ClearView();
            LoadActivityUI();
            OnPropertyChanged(nameof(DayOfActivities));
        }

        private void Next()
        {
            MainDate = MainDate.AddDays(7);
            ClearView();
            LoadActivityUI();
            OnPropertyChanged(nameof(DayOfActivities));
        }

        #endregion
    }
}
