using HorseTrackingMobile.Models;
using System.Collections.Generic;

namespace HorseTrackingMobile.Services.AppState
{
    public class AppState : IAppState
    {

        private Horse currentHorse;
        public Horse CurrentHorse
        {
            get => currentHorse;
            set => currentHorse = value;
        }

        private User currentUser;
        public User CurrentUser
        {
            get => currentUser;
            set => currentUser = value;
        }

        private List<Horse> horseList;
        public List<Horse> HorseList
        {
            get => horseList;
            set => horseList = value;
        }

        private List<User> listOfTrainer;
        public List<User> ListOfTrainer
        {
            get => listOfTrainer;
            set => listOfTrainer = value;
        }

        private List<Doctor> listOfDoctors;
        public List<Doctor> ListOfDoctors
        {
            get => listOfDoctors;
            set => listOfDoctors = value;
        }
    }
}
