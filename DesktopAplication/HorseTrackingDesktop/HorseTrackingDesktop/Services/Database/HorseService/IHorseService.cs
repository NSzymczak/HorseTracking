using HorseTrackingDesktop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Database.HorseService
{
    public interface IHorseService
    {
        Task<List<Horses>> GetHorses();

        Task<List<Horses>> GetAllHorses();

        Task<List<Status>> GetStatus();

        Task<List<HorseGenders>> GetGenders();

        Task AddHorse(Horses horse);

        Task DeleteHorse(Horses horse);

        Task EditHorse(Horses horse);

        Task<List<Activities>> GetHorseActivity(int horseID);
    }
}