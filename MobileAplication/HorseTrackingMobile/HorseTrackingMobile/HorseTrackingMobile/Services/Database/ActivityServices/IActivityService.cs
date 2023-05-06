using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Services.Database.ActivityServices
{
    public interface IActivityService
    {
        List<Activity> GetActivities(int horseID);
    }
}
