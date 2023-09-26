using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services.AppState;
using HorseTrackingMobile.Services.Database.HorseServices;
using HorseTrackingMobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using HorseTrackingMobile.Services.Database.UserServices;
using System.Windows.Input;
using Xamarin.Forms;
using HorseTrackingMobile.Services.Database.ShareHorseServices;

namespace HorseTrackingMobile.ViewModels
{
    public class ShareHorseSearchViewModel : BaseViewModel
    {
        private readonly IHorseService _horseService;
        private readonly IUserService _userService;
        private readonly IAppState _appState;
        private readonly IShareHorseServices _shareHorseServices;
        public ICommand Share { get; set; }
        public ObservableCollection<Horse> Horses { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public DateTime DateNow { get; set; } = DateTime.Now;

        private DateTime _endDate;

        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
            }
        }

        private Horse _selectedHorse;

        public Horse SelectedHorse
        {
            get
            {
                return _selectedHorse;
            }
            set
            {
                _selectedHorse = value;
                OnPropertyChanged(nameof(SelectedHorse));
            }
        }

        private User _selectedUser;

        public User SelectedUser
        {
            get
            {
                return _selectedUser;
            }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        public void Load()
        {
            var horseList = _horseService.GetHorses(_appState.CurrentUser.Id.ToString());
            if (horseList == null)
                return;
            Horses = new ObservableCollection<Horse>(horseList);
            OnPropertyChanged(nameof(Horses));

            if (Horses.Count > 0)
                SelectedHorse = Horses[0];

            var userList = _userService.GetAllUsers();
            if (userList == null)
                return;
            Users = new ObservableCollection<User>(userList);
            OnPropertyChanged(nameof(Users));

            if (Users.Count > 0)
                SelectedUser = Users[0];
        }

        public ShareHorseSearchViewModel(IHorseService horseService, IAppState appState,
            IUserService userService, IShareHorseServices shareHorseServices)
        {
            _horseService = horseService;
            _appState = appState;
            _userService = userService;
            _shareHorseServices = shareHorseServices;

            EndDate = DateTime.Now;

            Share = new Command(() =>
            {
                var horseID = SelectedHorse.ID.ToString();
                var shareUserID = _userService.GetHorseOwner(horseID).Id.ToString();
                if (SelectedUser == null)
                    return;
                _shareHorseServices.SaveShareFromQR(horseID, DateNow, EndDate, SelectedUser.Id.ToString(), shareUserID);
            });
        }
    }
}