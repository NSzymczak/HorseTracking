using HorseTrackingDesktop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Database.HorseService
{
    public interface IHorseService
    {
        public Task<List<Horses>> GetHorses();

        Task<List<Status>> GetStatus();

        Task<List<HorseGenders>> GetGenders();
    }
}