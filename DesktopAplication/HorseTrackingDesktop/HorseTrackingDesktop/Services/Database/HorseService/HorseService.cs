using HorseTrackingDesktop.Enumerable;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Database.HorseService
{
    public class HorseService : IHorseService
    {
        private readonly IAppState _appState;
        private readonly HorseTrackingContext _context;

        public HorseService(IAppState appState, HorseTrackingContext context)
        {
            _appState = appState;
            _context = context;
        }

        public async Task<List<Horses>> GetHorses()
        {
            if (_appState.CurrentUser.Type.TypeName == UserTypesEnum.horseOwner.ToString())
            {
                return await GetHorsesForUser(_appState.CurrentUser.UserId);
            }
            else if (_appState.CurrentUser.Type.TypeName == UserTypesEnum.trainer.ToString())
            {
                return await GetHorsesForTrainer(_appState.CurrentUser.UserId);
            }
            else if (_appState.CurrentUser.Type.TypeName == UserTypesEnum.admin.ToString())
            {
                return await GetAllHorses();
            }
            return new List<Horses>();
        }

        private Task<List<Horses>> GetHorsesForUser(int id)
        {
            var horses = _context.Horses.Include(s => s.Status)
                                        .Include(g => g.Gender)
                                        .Where(x => x.UserId == id)
                                        .Where(x => x.Status.Name == StatusEnum.active.ToString()
                                                 || x.Status.Name == StatusEnum.sent.ToString()
                                                 || x.Status.Name == StatusEnum.shared.ToString()).ToList();
            return Task.FromResult(horses);
        }

        private Task<List<Horses>> GetHorsesForTrainer(int id)
        {
            //Tu trzeba inna metodę
            var horses = _context.Horses.Include(s => s.Status)
                                        .Include(g => g.Gender).ToList();
            return Task.FromResult(horses);
        }

        private Task<List<Horses>> GetAllHorses()
        {
            var horses = _context.Horses.Include(s => s.Status)
                                        .Include(g => g.Gender).ToList();
            return Task.FromResult(horses);
        }
    }
}