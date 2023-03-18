using HorseTrackingDesktop.Database;
using HorseTrackingDesktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region INotify
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotify


        public ObservableCollection<Visit> visits { get; set; } = new();
        public ObservableCollection<Horse> horses { get; set; } = new();

        public Horse? currentHorse { get; set; }

        public void LoadHorses()
        {
            foreach (var horse in Horse.Horses)
            {
                horses.Add(horse);
            }

            if (horses == null)
                return;

            currentHorse = horses.FirstOrDefault();
            Horse.CurrentHorse = currentHorse;

        }

        public void LoadVisits()
        {
            GetDataFromDatabase.GetVisit();
            foreach (var visit in Visit.AllVisit)
            {
                visits.Add(visit);
            }
        }
    }
}
