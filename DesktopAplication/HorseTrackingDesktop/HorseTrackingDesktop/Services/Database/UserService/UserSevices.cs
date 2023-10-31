using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using PasswordHashing;

namespace HorseTrackingDesktop.Services.Database.UserService
{
    public class UserSevices : IUserServices
    {
        private readonly IAppState _appState;
        private readonly HorseTrackingContext _context;

        public UserSevices(IAppState appState, HorseTrackingContext context)
        {
            _appState = appState;
            _context = context;
        }

        public Task<UserAcounts?> GetUser(string login)
        {
            var user = _context.UserAcounts.Where(x => x.Login == login)
                                           .Include(x => x.Type)
                                           .Include(x => x.Detail)
                                           .Include(x => x.Horses).ToList().FirstOrDefault();
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

        public async Task AddUser(UserAcounts user)
        {
            try
            {
                var tempPassword = (user.Detail.Name + user.Detail.Surname).ToLower();
                user.Hash = PasswordHasher.Hash(tempPassword);
                user.CreatedDateTime = DateTime.Now;
                _context.UserAcounts.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task EditUser(UserAcounts user)
        {
            var oldUser = _context.UserAcounts.Where(x => x.UserId == user.UserId).FirstOrDefault();
            if (oldUser != null)
            {
                oldUser.UserId = user.UserId;
                oldUser.Login = user.Login;
                oldUser.Hash = user.Hash;
                oldUser.CreatedDateTime = user.CreatedDateTime;
                oldUser.Type = user.Type;
                oldUser.Detail = user.Detail;
            }
            await _context.SaveChangesAsync();
        }

        public Task<List<UserTypes>> GetUserTypes()
        {
            return Task.FromResult(_context.UserTypes.ToList());
        }

        public async Task ResetPassword(int id)
        {
            var user = _context.UserAcounts.FirstOrDefault(x => x.UserId == id);
            if (user == null)
            {
                return;
            }
            var tempPassword = (user.Detail.Name + user.Detail.Surname).ToLower();
            user.Hash = PasswordHasher.Hash(tempPassword);
            await _context.SaveChangesAsync();
        }
    }
}