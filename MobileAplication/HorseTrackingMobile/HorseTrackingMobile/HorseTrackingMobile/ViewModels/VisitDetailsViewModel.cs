using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services.AppState;
using HorseTrackingMobile.Services.Database.VisitServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HorseTrackingMobile.ViewModels
{
    [QueryProperty(nameof(VisitID), nameof(VisitID))]

    public class VisitDetailsViewModel : BaseViewModel
    {
        private readonly IAppState _appState;
        private readonly IVisitService _visitService;

        public ICommand AddVisitCommand { get; set; }


        int visitID;
        public int VisitID
        {
            get => visitID;
            set
            {
                visitID = value;
                LoadVisit(value);
            }
        }

        private string cost;
        public string Cost
        {
            get => cost;
            set => SetProperty(ref cost, value);
        }

        private string summary;
        public string Summary
        {
            get => summary;
            set => SetProperty(ref summary, value);
        }

        private DateTime visitDate;
        public DateTime VisitDate
        {
            get => visitDate;
            set => SetProperty(ref visitDate, value);
        }

        private Doctor doctor;
        public Doctor Doctor
        {
            get => doctor;
            set
            {
                SetProperty(ref doctor, value);
                OnPropertyChanged(nameof(Doctor));
            }
        }

        public List<Doctor> ListOfDoctors
        {
            get => _appState.ListOfDoctors;
        }

        public bool isEdit;

        public VisitDetailsViewModel(IAppState appState, IVisitService visitService)
        {
            _appState = appState;
            _visitService = visitService;

            SetDate();

            AddVisitCommand = new Command(() =>
            {
                try
                {
                    var visit = new Visit()
                    {
                        VisitID = visitID,
                        VisitDate = visitDate,
                        Cost = cost,
                        Doctor = doctor,
                        Summary = summary,
                        Horse = _appState.CurrentHorse
                    };
                    _visitService.AddVisit(visit);
                    _appState.CurrentHorse.ListOfVisit.Add(visit);
                    Shell.Current.Navigation.PopToRootAsync();
                }
                catch (Exception ex)
                {
#if DEBUG
                    App.Current.MainPage.DisplayAlert("Błąd", ex.Message, "dupa");
#endif
                    App.Current.MainPage.DisplayAlert("Błąd", $"Coś poszło nie tak, nie udało się {(isEdit ? "dodać" : "edytować")} aktywności", "Dobrze");
                    Shell.Current.GoToAsync("..");
                }
            });
        }
        private void SetDate()
        {
            VisitDate = DateTime.Now;
        }

        private void LoadVisit(int visitID)
        {
            try
            {
                var item = _appState.CurrentHorse.ListOfVisit.Where(x => x.VisitID == visitID).FirstOrDefault();
                if (item == null)
                    return;
                VisitDate = item.VisitDate;
                Doctor = item.Doctor;
                Cost = item.Cost;
                Summary = item.Summary;
                isEdit = true;
            }
            catch
            {
                 App.Current.MainPage.DisplayAlert("Błąd", "Coś poszło nie tak, nie udało się wczytać szczegółów", "Dobrze");
            }
        }
    }
}
