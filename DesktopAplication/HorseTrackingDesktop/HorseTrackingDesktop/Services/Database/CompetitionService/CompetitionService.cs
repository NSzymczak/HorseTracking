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

        public async Task<List<Competitions>> GetCompetitions()
        {
            return await _context.Competitions.ToListAsync();
        }

        public async Task<List<Contests>> GetContestsForCompetition(int competitionID)
        {
            return await _context.Contests.Where(x => x.CompetitionId == competitionID)
                .Include(x => x.Participations).ThenInclude(x => x.Horse).ToListAsync();
        }

        public async Task RemoveCompetition(int competitionID)
        {
            var contests = _context.Contests.Where(x => x.CompetitionId == competitionID);
            foreach (var contest in contests)
            {
                var participations = _context.Participations.Where(x => x.ContestId == contest.ContestId);
                foreach (var participation in participations)
                {
                    _context.Participations.Remove(participation);
                    await _context.SaveChangesAsync();
                }
                _context.Contests.Remove(contest);
                await _context.SaveChangesAsync();
            }
            var competition = _context.Competitions.FirstOrDefault(x => x.CompetitionId == competitionID);
            if (competition != null)
            {
                _context.Competitions.Remove(competition);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AsignHorseForContest(int horseID, int contestID)
        {
            var contest = _context.Contests.FirstOrDefault(contest => contest.ContestId == contestID);
            var horse = _context.Horses.FirstOrDefault(x => x.HorseId == horseID);
            if (horse == null || contest == null)
            {
                return;
            }
            var participation = new Participations()
            {
                Contest = contest,
                Horse = horse
            };
            _context.Participations.Add(participation);
            await _context.SaveChangesAsync();
        }

        public async Task AddCompetiton(Competitions competitions)
        {
            _context.Competitions.Add(competitions);
            await _context.SaveChangesAsync();
        }

        public async Task AddContests(List<Contests> contests)
        {
            _context.Contests.AddRange(contests);
            await _context.SaveChangesAsync();
        }

        public async Task EditCompetition(Competitions competitions)
        {
            var competitonEdit = _context.Competitions.FirstOrDefault(x => x.CompetitionId == competitions.CompetitionId);
            if (competitonEdit == null)
            {
                return;
            }
            competitonEdit.Spot = competitions.Spot;
            competitonEdit.Rank = competitions.Rank;
            competitonEdit.Date = competitions.Date;
            competitonEdit.Description = competitions.Description;

            foreach (var con in competitions.Contests)
            {
                var contest = _context.Contests.FirstOrDefault(x => x.ContestId == con.CompetitionId);
                if (contest == null)
                {
                    continue;
                }
                contest.Level = con.Level;
                contest.Name = con.Name;
                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveParticipation(int id)
        {
            var participation = _context.Participations.FirstOrDefault(x => x.ParticipationId == id);
            if (participation == null)
            {
                return;
            }
            _context.Participations.Remove(participation);
            await _context.SaveChangesAsync();
        }
    }
}