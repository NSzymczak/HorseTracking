using HorseTrackingDesktop.Enumerable;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using HorseTrackingDesktop.Services.Database.UserService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Database.HorseService
{
    public class HorseService : IHorseService
    {
        private readonly IAppState _appState;
        private readonly IUserServices _userService;
        private readonly HorseTrackingContext _context;

        public HorseService(IAppState appState, IUserServices userServices,
                            HorseTrackingContext context)
        {
            _appState = appState;
            _userService = userServices;
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
            var horses = _context.Horses.Where(x => x.UserId == id &&
                                              (x.Status.Name == StatusEnum.active.ToString() ||
                                               x.Status.Name == StatusEnum.sent.ToString() ||
                                               x.Status.Name == StatusEnum.shared.ToString())).ToList();

            foreach (var horse in horses)
            {
                _context.Entry(horse).Reference(h => h.Status).Load();
                _context.Entry(horse).Reference(h => h.Gender).Load();
            }

            return Task.FromResult(horses);
        }

        private Task<List<Horses>> GetHorsesForTrainer(int id)
        {
            //Tu trzeba inna metodę
            var horses = _context.Horses.Include(s => s.Status)
                                        .Include(g => g.Gender).ToList();
            return Task.FromResult(horses);
        }

        public Task<List<Horses>> GetAllHorses()
        {
            var horses = _context.Horses.Include(s => s.Status)
                                        .Include(g => g.Gender).ToList();
            return Task.FromResult(horses);
        }

        public Task<List<Status>> GetStatus()
        {
            return Task.FromResult(_context.Status.ToList());
        }

        public Task<List<HorseGenders>> GetGenders()
        {
            return Task.FromResult(_context.HorseGenders.ToList());
        }

        public async Task AddHorse(Horses horse)
        {
            try
            {
                var type = (await _userService.GetUserTypes()).Where(x => x.TypeName == UserTypesEnum.horseOwner.ToString())
                                                               .Select(x => x.TypeId).FirstOrDefault();
                horse.User.TypeId = type;
                _context.Horses.Add(horse);
                int changesSaved = _context.SaveChanges();

                if (changesSaved > 0)
                {
                    Console.WriteLine("Zapis danych do bazy danych zakończony sukcesem. Liczba zmian: " + changesSaved);
                }
                else
                {
                    Console.WriteLine("Brak zmian do zapisania w bazie danych.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd podczas zapisu danych do bazy danych: " + ex.Message);
            }
        }

        public async Task DeleteHorse(Horses horse)
        {
            var user = horse.User;
            _context.Horses.Remove(horse);
            _context.SaveChanges();
            var horsesCount = _context.Horses.Count(x => x.User.UserId == user.UserId);

            if (horsesCount == 0)
            {
                var userToEdit = _context.UserAcounts.Where(x => x.UserId == user.UserId).FirstOrDefault();
                if (userToEdit != null)
                {
                    var typeID = (await _userService.GetUserTypes()).Where(x => x.TypeName == UserTypesEnum.appOwner.ToString())
                                   .Select(x => x.TypeId).FirstOrDefault();
                    userToEdit.TypeId = typeID;
                }
            }
            _context.SaveChanges();
        }

        public Task EditHorse(Horses horse)
        {
            var oldHorse = _context.Horses.Where(x => x.HorseId == horse.HorseId).FirstOrDefault();
            if (oldHorse != null)
            {
                oldHorse.HorseId = horse.HorseId;
                oldHorse.Breeder = horse.Breeder;
                oldHorse.Father = horse.Father;
                oldHorse.Mother = horse.Mother;
                oldHorse.Gender = horse.Gender;
                oldHorse.Status = horse.Status;
                oldHorse.Name = horse.Name;
                oldHorse.Passport = horse.Passport;
                oldHorse.Race = horse.Race;
                oldHorse.User = horse.User;
            }
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<List<Activities>> GetHorseActivity(int horseID)
        {
            var activities = _context.Activities.Where(x => x.HorseId == horseID).ToList();
            return Task.FromResult(activities);
        }
    }
}