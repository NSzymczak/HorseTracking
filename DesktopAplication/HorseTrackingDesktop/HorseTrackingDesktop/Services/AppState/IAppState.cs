using HorseTrackingDesktop.Models;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingDesktop.Services.AppState
{
    public interface IAppState
    {
        Horses? CurrentHorse { get; set; }
        UserAcounts? CurrentUser { get; set; }
        List<Horses>? HorseList { get; set; }
        List<UserAcounts>? ListOfTrainer { get; set; }
        List<Professionals>? ListOfProfessionals { get; set; }
    }
}
