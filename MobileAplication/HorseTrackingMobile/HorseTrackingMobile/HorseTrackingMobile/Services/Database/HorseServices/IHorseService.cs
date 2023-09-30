using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Services.Database.HorseServices
{
    public interface IHorseService
    {
        Horse GetHorse(string id);

        List<Horse> GetHorses(string user);

        List<Horse> GetAllTrainedHorses(string user);

        List<Horse> GetHorsesForUser();
    }
}