using HorseTrackingDesktop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Database.UserService
{
    public interface IUserServices
    {
        Task<UserAcounts?> GetUser(string login, string hash);
        Task<List<UserAcounts>> GetTrainers();
    }
}
