using HorseTrackingDesktop.Models;
using System.Collections.Generic;

namespace HorseTrackingDesktop.Services.AppState
{
    public class AppState : IAppState
    {

        private Horses? currentHorse;
        public Horses? CurrentHorse
        {
            get => currentHorse;
            set => currentHorse = value;
        }

        private UserAcounts currentUser;
        public UserAcounts CurrentUser
        {
            get => currentUser;
            set => currentUser = value;
        }

        private List<Horses>? horseList;
        public List<Horses>? HorseList
        {
            get => horseList;
            set => horseList = value;
        }

        private List<UserAcounts>? listOfTrainer;
        public List<UserAcounts>? ListOfTrainer
        {
            get => listOfTrainer;
            set => listOfTrainer = value;
        }

        private List<Professionals>? listOfProfessionals;
        public List<Professionals>? ListOfProfessionals
        {
            get => listOfProfessionals;
            set => listOfProfessionals = value;
        }
    }
}
