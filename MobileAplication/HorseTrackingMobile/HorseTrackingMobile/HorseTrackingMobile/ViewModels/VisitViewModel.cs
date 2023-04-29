using HorseTrackingMobile.Database;
using HorseTrackingMobile.Models;
using HorseTrackingMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HorseTrackingMobile.ViewModels
{
    public class VisitViewModel : HorseAppViewModel
    {
        public ICommand VisitTapped { get; set; }
        public ObservableCollection<Visit> Visits { get; set; } = new ObservableCollection<Visit>();
        public VisitViewModel() 
        {
            VisitTapped = new Command<Visit>(VisitDetails);
            SwitchHorseCommand = new Command(() =>
            {
                Horse.CurrentHorse = CurrentHorse;
                LoadVisit();
            });
        }

        public void Load()
        {
            CurrentHorse = Horse.CurrentHorse;
            LoadVisit();
        }

        private void LoadVisit()
        {
            Visits.Clear();
            foreach (var visit in DataBaseConnection.GetVisits(CurrentHorse.ID))
            {
                Visits.Add(visit);
            }
        }

        public async void VisitDetails(Visit visit)
        {
            if (visit == null)
                return;

            // This will push the ActivityDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(VisitDetailsView)}?{nameof(VisitDetailsViewModel.VisitID)}={visit.VisitID}");
        }
    }
}
