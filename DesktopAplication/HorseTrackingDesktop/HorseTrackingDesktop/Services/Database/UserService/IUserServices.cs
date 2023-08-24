using HorseTrackingDesktop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Database.UserService
{
    public interface IUserServices
    {
        Task<UserAcounts?> GetUser(string login);

        Task<List<UserAcounts>> GetTrainers();

        Task<List<UserAcounts>> GetAllUsers();

        Task<List<UserTypes>> GetUserTypes();

        Task AddUser(UserAcounts user);

        Task EditUser(UserAcounts user);
    }
}