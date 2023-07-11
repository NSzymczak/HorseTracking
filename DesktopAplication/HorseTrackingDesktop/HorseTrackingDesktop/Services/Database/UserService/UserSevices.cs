using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Database.UserService
{
    public class UserSevices: IUserServices
    {
        private readonly IAppState _appState;
        public UserSevices(IAppState appState)
        {
            _appState = appState;
            //_appState.ListOfTrainer = GetTrainers().Result;
        }

        public Task<UserAcounts?> GetUser(string login, string hash)
        {
            using var context = new HorseTrackingContext();
            var user = context.UserAcounts.Where(x => x.Login == login && x.Hash == hash).ToList().FirstOrDefault();
            return Task.FromResult(user);
        }

        public Task<List<UserAcounts>> GetTrainers()
        {
            using var context = new HorseTrackingContext();
            var trainers = context.UserAcounts.Where(x => x.TypeId == 4).ToList();
            return Task.FromResult(trainers);
        }
    }
}
