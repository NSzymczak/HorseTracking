using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingMobile.Services
{
    public interface IAppShellRoutingService
    {
        void GoToLogin();
        void GoToActivityDetails(Activity activity);
        void GoToAddActivity();
        void GoToAddActivity(Activity activity);
        void GoToAddVisit();
    }
}
