using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Services.Database.CompetitionService
{
    public interface ICompetitionService
    {
        List<Participation> GetParticipation(int userID);
    }
}