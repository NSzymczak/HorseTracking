using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services;
using HorseTrackingMobile.Services.Database;
using HorseTrackingMobile.Services.Database.HorseServices;
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

        public HorseAppViewModel(IAppState appState) 
        {
            Horses = new ObservableCollection<Horse>(appState.HorseList);
            CurrentHorse = appState.CurrentHorse;
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
        //public User CurrentUser
        //{
        //    get { return currentUser; }
        //    set
        //    {
        //        if (currentUser != value)
        //        {
        //            currentUser = value;
        //            OnPropertyChanged(nameof(CurrentUser));
        //        }
        //    }
        //}
    }
}
