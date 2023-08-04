using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using HorseTrackingDesktop.Services.Hasher;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HorseTrackingDesktop.Services.Database.UserService
{
    public class UserSevices : IUserServices
    {
        private readonly IAppState _appState;
        private readonly IHasher _hasher;
        private readonly HorseTrackingContext _context;

        public UserSevices(IAppState appState, HorseTrackingContext context, IHasher hasher)
        {
            _appState = appState;
            _context = context;
            _hasher = hasher;
        }

        public Task<UserAcounts?> GetUser(string login)
        {
            var user = _context.UserAcounts.Where(x => x.Login == login).Include(x => x.Type).ToList().FirstOrDefault();
            return Task.FromResult(user);
        }

        public Task<List<UserAcounts>> GetAllUsers()
        {
            var listOfUsers = _context.UserAcounts.Include(i => i.Type).Include(i => i.Detail).ToList();
            return Task.FromResult(listOfUsers);
        }

        public Task<List<UserAcounts>> GetTrainers()
        {
            var trainers = _context.UserAcounts.Where(x => x.TypeId == 4).ToList();
            return Task.FromResult(trainers);
        }

        public Task AddUser(UserAcounts user)
        {
            try
            {
                var tempPassword = (user.Detail.Name + user.Detail.Surname).ToLower();
                var hashAndSalt = _hasher.HashPassword(tempPassword);
                user.Hash = hashAndSalt[0];
                user.Salt = hashAndSalt[1];
                user.CreatedDateTime = DateTime.Now;
                _context.UserAcounts.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return Task.CompletedTask;
        }

        public Task EditUser(UserAcounts user)
        {
            var oldUser = _context.UserAcounts.Where(x => x.UserId == user.UserId).FirstOrDefault();
            if (oldUser != null)
            {
                oldUser.UserId = user.UserId;
                oldUser.Login = user.Login;
                oldUser.Salt = user.Salt;
                oldUser.Hash = user.Hash;
                oldUser.CreatedDateTime = user.CreatedDateTime;
                oldUser.Type = user.Type;
                oldUser.Detail = user.Detail;
            }
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<List<UserTypes>> GetUserTypes()
        {
            return Task.FromResult(_context.UserTypes.ToList());
        }
    }
}