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
        public Command<Activity> ActivityTapped { get; set; }
        public Command ChangeHorse { get; set; }
        public ActivityViewModel() 
        {
            PrevCommand = new Command(Prev);
            NextCommand = new Command(Next);
            ActivityTapped = new Command<Activity>(ActivitySelected);
            ChangeHorse = new Command(SwitchHorse);
            AddCommand = new Command(AddActivity);
        }
        public ObservableCollection<DayOfActivity> DayOfActivities { get; set; } = new ObservableCollection<DayOfActivity>();

        public Horse SelectedHorse { get; set; }

        public DateTime MainDate { get; set; }

        public List<Activity> ListOfActivity { get; set; }
        
        public List<Horse> Horses { get; set; } 


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

        public void SwitchHorse()
        {
            
        }
        public void Load()
        {
            LoadHorses();
            SetMainDate();
            LoadActivityUI();
        }

        public void LoadActivityUI()
        {
            if (!ListServices.IsAny(DayOfActivities))
            {
                DayOfActivities.Clear();
                ListOfActivity.Clear();
            }

            AddList();
            AsignActivityToDays();
        }

        public void LoadHorses()
        {
            Horses = DataBaseOperation.GetAllUserHorses(); //pobranie koni
            SelectedHorse = Horses.FirstOrDefault();
            Horse.CurrentHorse=SelectedHorse;
            OnPropertyChanged(nameof(Horses));
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
                    ListOfActivity=new ObservableCollection<Activity>()
                };
                DayOfActivities.Add(dayOfActivity);
            }
        }

        public void AsignActivityToDays()
        {
            Activity.Activities = TemporaryAdding.AddActivity();
            ListOfActivity = Activity.Activities;
            ListOfActivity =ListOfActivity.Where(x=> x.Date>=MainDate && x.Date<=MainDate.AddDays(7)).ToList();
           foreach(var activity in ListOfActivity)
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

        async void ActivitySelected(Activity activity)
        {
            if (activity == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ActivityDetailsView)}?{nameof(ActivityDetailsViewModel.ActivityID)}={activity.ID}");
        }

        async void AddActivity()
        {
            var ID= TemporaryAdding.AddActivity().Count+1;
            var activity = new Activity()
            { 
                ID=ID,
                Horse = Horse.CurrentHorse,
                User = User.CurrentUser,
                Date = DateTime.Now,
            };
            Activity.Activities.Add(activity); 
            await Shell.Current.GoToAsync($"{nameof(AddActivityView)}?{nameof(ActivityDetailsViewModel.ActivityID)}={activity.ID}");


        }
        public void ClearView()
        {
            DayOfActivities.Clear();
        }

        public async void Prev()
        {
            MainDate = MainDate.AddDays(-7);
            ClearView();
            LoadActivityUI();
            OnPropertyChanged(nameof(DayOfActivities));
        }

        public async void Next()
        {
            MainDate = MainDate.AddDays(7);
            ClearView();
            LoadActivityUI();
            OnPropertyChanged(nameof(DayOfActivities));
        }
    }
}
