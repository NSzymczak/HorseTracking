using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services;
using HorseTrackingMobile.Services.AppState;
using HorseTrackingMobile.Services.Database;
using HorseTrackingMobile.Services.Database.VisitServices;
using HorseTrackingMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HorseTrackingMobile.ViewModels
{
    public class VisitViewModel : BaseViewModel
    {
        private readonly IVisitService _visitServices;
        private readonly IAppState _appState;
        private readonly IAppShellRoutingService _appShellRoutingService;

        public ICommand VisitTapped { get; set; }
        public ICommand VisitDoubleTapped { get; set; }
        public ICommand VisitLongTapped { get; set; }
        public ICommand SwitchHorseCommand { get; set; }
        public ICommand AddVisitCommand { get; set; }

        public bool CanModifyData => _appState.CurrentUser.Type.Type == "horseOwner";

        public ObservableCollection<Visit> Visits { get; set; }
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

        public VisitViewModel(IVisitService visitServices, IAppState appState, IAppShellRoutingService appShellRoutingService)
        {
            _visitServices = visitServices;
            _appState = appState;
            _appShellRoutingService= appShellRoutingService;

            Horses = new ObservableCollection<Horse>(appState.HorseList);
            CurrentHorse = appState.CurrentHorse;
            VisitTapped = new Command<Visit>(async (visit) =>
            {
                if (visit == null)
                    return;
                await Shell.Current.GoToAsync($"{nameof(VisitDetailsView)}?{nameof(VisitDetailsViewModel.VisitID)}={visit.VisitID}");
            });
            VisitDoubleTapped = new Command<Visit>(async (visit) =>
            {
                if (visit == null)
                    return;
                await Shell.Current.GoToAsync($"{nameof(AddVisitView)}?{nameof(VisitDetailsViewModel.VisitID)}={visit.VisitID}");
            });
            VisitLongTapped = new Command<Visit>(async(visit) =>
            {
                if(await App.Current.MainPage.DisplayAlert("Usunięcie wizyty", $"Czy chcesz usunąć wizytę z dnia {visit.VisitDate.ToShortDateString()} ?", "Tak", "Nie"))
                {
                    _visitServices.DeleteVisit(visit.VisitID);
                }
                LoadVisit();
            });
            SwitchHorseCommand = new Command(() =>
            {
                appState.CurrentHorse = CurrentHorse;
                LoadVisit();
            });
            AddVisitCommand = new Command(() =>
            {
                _appShellRoutingService.GoToAddVisit();
            });
        }

        public void LoadVisit()
        {
            CurrentHorse = _appState.CurrentHorse;
            CurrentHorse.ListOfVisit = _visitServices.GetVisits(CurrentHorse.ID);
            Visits = new ObservableCollection<Visit>(CurrentHorse.ListOfVisit);
            OnPropertyChanged(nameof(Visits));
        }
    }
}
