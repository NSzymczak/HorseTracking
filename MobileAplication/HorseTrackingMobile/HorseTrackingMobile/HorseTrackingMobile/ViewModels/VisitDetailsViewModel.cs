using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace HorseTrackingMobile.ViewModels
{
    [QueryProperty(nameof(VisitID), nameof(VisitID))]

    public class VisitDetailsViewModel: HorseAppViewModel
    {

        int visitID;
        public int VisitID
        {
            get
            {
                return visitID;
            }
            set
            {
                visitID = value;
                LoadVisit(value);
            }
        }

        private string cost;
        public string Cost 
        { 
            get=>cost; 
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
            set => SetProperty(ref doctor, value);
        }

        private async void LoadVisit(int visitID)
        {
            try
            {
                var item = Horse.CurrentHorse.ListOfVisit.Select(x => x).Where(x => x.VisitID == visitID).FirstOrDefault();
                if (item == null) return;
                VisitDate= item.VisitDate;
                Doctor = item.Doctor;
                Cost= item.Cost;
                Summary = item.Summary;
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Błąd", "Coś poszło nie tak, nie udało się wczytać szczegółów", "Dobrze");
            }
        }
    }
}
