using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Services.Database.HorseServices
{
    public interface IHorseService
    {
        Horse GetHorse(string id);
        List<Horse> GetHorses(User user);
        List<Horse> GetAllTrainedHorses(User user);
    }
}
