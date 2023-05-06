using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Services
{
    public interface IAppState
    {
        Horse CurrentHorse { get; set; }
        User CurrentUser { get; set; }
        List<Horse> HorseList { get;set; }

    }
}
