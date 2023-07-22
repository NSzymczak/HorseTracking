using HorseTrackingDesktop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Database.VisitService
{
    public interface IVisitService
    {
        Task<List<Visits>> GetAllVisit(int horseID);

        Task RemoveVisit(Visits visits);

        Task AddVisit(Visits visits);

        Task EditVisit(Visits editedVisit, int id);

        Task<List<Professionals>> GetProfessionals();
    }
}