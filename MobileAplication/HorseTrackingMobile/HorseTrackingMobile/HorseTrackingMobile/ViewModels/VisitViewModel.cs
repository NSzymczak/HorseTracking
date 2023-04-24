using HorseTrackingMobile.Database;
using HorseTrackingMobile.Models;
using HorseTrackingMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace HorseTrackingMobile.ViewModels
{
    public class VisitViewModel : BaseViewModel
    {
        public Command VisitTapped { get; set; }
        public ObservableCollection<Visit> Visits { get; set; } = new ObservableCollection<Visit>();
        public VisitViewModel() 
        {
            VisitTapped = new Command<Visit>(VisitDetails);
        }
        public void Load()
        {
            Visits.Clear();
            var vistList = DataBaseConnection.GetVisits(CurrentHorse.ID);
            foreach (var visit in vistList)
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
