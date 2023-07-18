using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Services.AppState
{
    public interface IAppState
    {
        Horse CurrentHorse { get; set; }
        User CurrentUser { get; set; }
        List<Horse> HorseList { get; set; }
        List<User> ListOfTrainer { get; set; }
        List<Doctor> ListOfDoctors { get; set; }
    }
}
