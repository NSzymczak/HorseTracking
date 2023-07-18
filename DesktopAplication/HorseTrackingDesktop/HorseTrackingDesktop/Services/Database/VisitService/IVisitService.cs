using HorseTrackingDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Database.VisitService
{
    public interface IVisitService
    {
        Task<List<Visits>> GetAllVisit(int horseID);
    }
}
