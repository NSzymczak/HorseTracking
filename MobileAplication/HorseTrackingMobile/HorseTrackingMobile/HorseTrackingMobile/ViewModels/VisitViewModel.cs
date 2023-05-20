using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services;
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
        public ICommand VisitTapped { get; set; }
        public ICommand SwitchHorseCommand { get; set; }
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
        private readonly IVisitService _visitServices;
        private readonly IAppState _appState;
        public VisitViewModel(IVisitService visitServices, IAppState appState)
        {
            _visitServices = visitServices;
            _appState = appState;

            Horses = new ObservableCollection<Horse>(appState.HorseList);
            CurrentHorse = appState.CurrentHorse;
            VisitTapped = new Command<Visit>(async (visit) =>
            {
                if (visit == null)
                    return;
                await Shell.Current.GoToAsync($"{nameof(VisitDetailsView)}?{nameof(VisitDetailsViewModel.VisitID)}={visit.VisitID}");
            });
            SwitchHorseCommand = new Command(() =>
            {
                appState.CurrentHorse = CurrentHorse;
                LoadVisit();
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
