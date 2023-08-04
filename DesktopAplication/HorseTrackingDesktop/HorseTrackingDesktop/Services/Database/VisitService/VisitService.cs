using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        public Task RemoveVisit(Visits visits)
        {
            _context.Visits.Remove(visits);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task AddVisit(Visits visits)
        {
            _context.Visits.Add(visits);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task EditVisit(Visits editedVisit, int id)
        {
            var visit = _context.Visits.Where(x => x.VisitId == id).FirstOrDefault();
            if (visit != null)
            {
                visit.VisitDate = editedVisit.VisitDate;
                visit.Cost = editedVisit.Cost;
                visit.Horse = editedVisit.Horse;
                visit.Professional = editedVisit.Professional;
                visit.Summary = editedVisit.Summary;
                _context.SaveChanges();
            }
            return Task.CompletedTask;
        }

        public Task<List<Professionals>> GetProfessionals(bool includeAll = false)
        {
            if (includeAll)
                return Task.FromResult(_context.Professionals.Include(i => i.Detail).Include(s => s.Specialisation).ToList());

            return Task.FromResult(_context.Professionals.Include(i => i.Detail).ToList());
        }

        public Task RemoveProfessionalDate(Professionals professional)
        {
            var profToDelete = _context.Professionals.Where(x => x.ProfessionalId == professional.ProfessionalId).First();
            _context.Professionals.Remove(profToDelete);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task AddProfessional(Professionals professional)
        {
            _context.Professionals.Add(professional);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task EditProfessional(Professionals professional)
        {
            var oldProfessional = _context.Professionals.Where(x => x.ProfessionalId == professional.ProfessionalId).FirstOrDefault();
            if (oldProfessional != null)
            {
                oldProfessional.ProfessionalId = professional.ProfessionalId;
                oldProfessional.Degree = professional.Degree;
                oldProfessional.Specialisation = professional.Specialisation;
                oldProfessional.Detail = professional.Detail;
            }
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<List<Specialisations>> GetSpecialisations()
        {
            return Task.FromResult(_context.Specialisations.ToList());
        }
    }
}