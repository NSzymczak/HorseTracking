using HorseTrackingMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HorseTrackingMobile.Services.Database.VisitServices
{
    public interface IVisitService
    {
        List<Visit> GetVisits(int visitID);
        void AddVisit(Visit visit);
        void DeleteVisit(int ID);
    }
}
