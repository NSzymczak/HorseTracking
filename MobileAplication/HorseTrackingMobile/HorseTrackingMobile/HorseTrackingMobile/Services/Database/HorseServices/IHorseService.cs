using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Services.Database.HorseServices
{
    public interface IHorseService
    {
        List<Horse> GetHorses();
    }
}
