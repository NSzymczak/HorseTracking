using HorseTrackingDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Database.CompetitionService
{
    public interface ICompetitionService
    {
        Task<List<Competitions>> GetCompetitions();

        Task<List<Contests>> GetContestsForCompetition(int competitionID);

        Task RemoveCompetition(int competitionID);

        Task AsignHorseForContest(int contestID, int horseID);

        Task AddCompetiton(Competitions competitions);

        Task AddContests(List<Contests> contests);

        Task EditCompetition(Competitions competitions);

        Task RemoveParticipation(int id);

        Task<List<Participations>> GetHorseParticipation(int horseId);
    }
}