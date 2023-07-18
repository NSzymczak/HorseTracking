using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Database.VisitService
{
    public class VisitService : IVisitService
    {
        private readonly IAppState _appState;
        private readonly HorseTrackingContext _context;
        public VisitService(IAppState appState, HorseTrackingContext context)
        {
            _appState = appState;
            _context = context;
        }

        public Task<List<Visits>> GetAllVisit(int horseID)
        {
            var listOfUsers = _context.Visits.Where(i => i.HorseId == horseID).
                                              Include(i => i.Horse).
                                              Include(i => i.Professional).
                                              Include(i => i.Professional.Detail).
                                              Include(i => i.Professional.Specialisation).ToList();
            return Task.FromResult(listOfUsers);
        }
    }
}
