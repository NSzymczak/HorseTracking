using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.Database.HorseService;
using HorseTrackingDesktop.Services.Database.UserService;
using HorseTrackingDesktop.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HorseTrackingDesktop.ViewModel
{
    public partial class AddUserForHorseViewModel : BaseViewModel
    {
        private readonly IUserServices _userServices;
        private readonly IHorseService _horseService;

        public Horses Horse { get; set; }
        public List<UserAcounts>? UserAcounts { get; set; }
        public UserAcounts? CurrentAcount { get; set; }

        public AddUserForHorseViewModel(IUserServices userServices, IHorseService horseService)
        {
            _userServices = userServices;
            _horseService = horseService;
        }

        public async Task SetUp()
        {
            UserAcounts = await _userServices.GetAllUsers();

            if (Horse?.User != null)
            {
                CurrentAcount = Horse.User;
            }
            else if (UserAcounts.Count != 0)
            {
                CurrentAcount = UserAcounts.First();
            }

            OnPropertyChanged(nameof(CurrentAcount));
            OnPropertyChanged(nameof(UserAcounts));
        }

        [RelayCommand]
        public async Task AddHorseWithUser(Window window)
        {
            Horse.User = CurrentAcount;
            if (Horse.HorseId == 0)
            {
                await _horseService.AddHorse(Horse);
            }
            else
            {
                await _horseService.EditHorse(Horse);
            }
            window.Close();
        }
    }
}