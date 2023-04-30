using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Database.HorseServices
{
    public interface IHorseService
    {
        List<Horse> GetHorses();
    }
}
