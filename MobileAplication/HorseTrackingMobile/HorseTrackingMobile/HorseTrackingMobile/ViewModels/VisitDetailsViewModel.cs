using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HorseTrackingMobile.ViewModels
{
    [QueryProperty(nameof(VisitID), nameof(VisitID))]

    public class VisitDetailsViewModel:BaseViewModel
    {
        public int VisitID { get; set; }

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

        private PeopleDetails peopleDetails;
        public PeopleDetails PeopleDetails
        {
            get => peopleDetails;
            set => SetProperty(ref peopleDetails, value);
        }

        private Doctor doctor;
        public Doctor Doctor
        {
            get => doctor;
            set => SetProperty(ref doctor, value);
        }
    }
}
