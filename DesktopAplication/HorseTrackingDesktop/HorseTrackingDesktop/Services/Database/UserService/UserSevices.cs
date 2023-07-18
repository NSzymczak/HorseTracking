using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Database.UserService
{
    public class UserSevices: IUserServices
    {
        private readonly IAppState _appState;
        private readonly HorseTrackingContext _context;
        public UserSevices(IAppState appState, HorseTrackingContext context)
        {
            _appState = appState;
            _context = context;
        }

        public Task<UserAcounts?> GetUser(string login, string hash)
        {
            var user = _context.UserAcounts.Where(x => x.Login == login && x.Hash == hash).Include(x=>x.Horses).ToList().FirstOrDefault();
            return Task.FromResult(user);
        }

        public Task<List<UserAcounts>> GetAllUsers()
        {
            var listOfUsers = _context.UserAcounts.Include(i=>i.Type).Include(i=>i.Detail).ToList();
            return Task.FromResult(listOfUsers);
        }

        public Task<List<UserAcounts>> GetTrainers()
        {
            var trainers = _context.UserAcounts.Where(x => x.TypeId == 4).ToList();
            return Task.FromResult(trainers);
        }
    }
}
