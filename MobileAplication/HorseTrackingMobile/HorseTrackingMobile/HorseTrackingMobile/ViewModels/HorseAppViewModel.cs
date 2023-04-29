using HorseTrackingMobile.Database;
using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HorseTrackingMobile.ViewModels
{
    public class HorseAppViewModel :BaseViewModel
    {
        public ICommand SwitchHorseCommand { get; set; }
        public ObservableCollection<Horse> Horses { get; set; }

        public HorseAppViewModel() 
        {
            Horses = new ObservableCollection<Horse>(DataBaseConnection.GetHorses());
            if(Horse.CurrentHorse == null)
            {
                Horse.CurrentHorse = Horses.First();
            }
            CurrentHorse = Horse.CurrentHorse;
            CurrentUser = User.CurrentUser;
        }

        private Horse currentHorse;
        public Horse CurrentHorse {
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
        private User currentUser;
        public User CurrentUser
        {
            get { return currentUser; }
            set
            {
                if (currentUser != value)
                {
                    currentUser = value;
                    OnPropertyChanged(nameof(CurrentUser));
                }
            }
        }
    }
}
