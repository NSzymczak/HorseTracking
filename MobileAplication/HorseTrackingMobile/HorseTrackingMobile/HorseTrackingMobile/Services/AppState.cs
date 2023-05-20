using HorseTrackingMobile.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;

namespace HorseTrackingMobile.Services
{
    public class AppState : IAppState
    {

        private Horse currentHorse;
        public Horse CurrentHorse
        {
            get 
            { 
                return currentHorse; 
            }
            set
            {
                currentHorse = value;
            }
        }

        private User currentUser;
        public User CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

        private List<Horse> horseList;
        public List<Horse> HorseList
        {
            get
            {
                return horseList;
            }
            set
            {
                horseList = value;
            }
        }

    }
}
