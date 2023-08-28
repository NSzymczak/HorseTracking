using HorseTrackingDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HorseTrackingDesktop.Services.Database.CompetitionService
{
    public class CompetitionService : ICompetitionService
    {
        private readonly HorseTrackingContext _context;

        public CompetitionService(HorseTrackingContext context)
        {
            _context = context;
        }

        public Task<List<Competitions>> GetCompetitions()
        {
            var competitionList = _context.Competitions.ToList();
            return Task.FromResult(competitionList);
        }

        public Task<List<Contests>> GetContestsForCompetition(int competitionID)
        {
            var contestList = _context.Contests.Where(x => x.CompetitionId == competitionID)
                .Include(x => x.Participations).ThenInclude(x => x.Horse).ToList();
            return Task.FromResult(contestList);
        }

        public Task RemoveCompetition(int competitionID)
        {
            var contests = _context.Contests.Where(x => x.CompetitionId == competitionID);
            foreach (var contest in contests)
            {
                var participations = _context.Participations.Where(x => x.ContestId == contest.ContestId);
                foreach (var participation in participations)
                {
                    _context.Participations.Remove(participation);
                    _context.SaveChanges();
                }
                _context.Contests.Remove(contest);
                _context.SaveChanges();
            }
            var competition = _context.Competitions.FirstOrDefault(x => x.CompetitionId == competitionID);
            if (competition != null)
            {
                _context.Competitions.Remove(competition);
                _context.SaveChanges();
            }
            return Task.CompletedTask;
        }
    }
}