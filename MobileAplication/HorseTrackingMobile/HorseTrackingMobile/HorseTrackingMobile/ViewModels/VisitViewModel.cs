using HorseTrackingMobile.Models;
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
    public class VisitViewModel : HorseAppViewModel
    {
        public ICommand VisitTapped { get; set; }
        public ObservableCollection<Visit> Visits { get; set; }

        private readonly IVisitService _visitServices;

        public VisitViewModel(IVisitService visitServices) 
        {
            _visitServices = visitServices;
            VisitTapped = new Command<Visit>(async(visit) =>
            {
                if (visit == null)
                    return;
                await Shell.Current.GoToAsync($"{nameof(VisitDetailsView)}?{nameof(VisitDetailsViewModel.VisitID)}={visit.VisitID}");
            });
            SwitchHorseCommand = new Command(() =>
            {
                Horse.CurrentHorse = CurrentHorse;
                LoadVisit();
            });
        }

        public void LoadVisit()
        {
            CurrentHorse.ListOfVisit = _visitServices.GetVisits(CurrentHorse.ID);
            Visits = new ObservableCollection<Visit>(CurrentHorse.ListOfVisit);
            OnPropertyChanged(nameof(Visits));
        }
    }
}
