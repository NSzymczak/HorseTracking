using HorseTrackingDesktop.Enumerable;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
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

        public Task AddHorse(Horses horse)
        {
            try
            {
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
            return Task.CompletedTask;
        }

        public Task DeleteHorse(Horses horse)
        {
            _context.Horses.Remove(horse);
            _context.SaveChanges();
            return Task.CompletedTask;
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
    }
}