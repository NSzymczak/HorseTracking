using HorseTrackingMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using HorseTrackingMobile.Models;
using System.Linq;
using HorseTrackingMobile.Services;
using HorseTrackingMobile.Database;
using System.Windows.Input;
using HorseTrackingMobile.Services.Database.UserServices;
using HorseTrackingMobile.Services.Database.HorseServices;
using System.Security.Cryptography;
using HorseTrackingMobile.Services.AppState;
using HorseTrackingMobile.Services.Database.ShareHorseServices;

namespace HorseTrackingMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly IAppState _appState;
        private readonly IHorseService _horseService;
        private readonly IShareHorseServices _shareHorseServices;
        public ICommand LoginCommand { get; }

        public bool WrongData { get; set; }

        private string readedLogin;

        public string ReadedLogin
        {
            get => readedLogin;
            set => SetProperty(ref readedLogin, value);
        }

        private string readedPassword;

        public string ReadedPassword
        {
            get => readedPassword;
            set => SetProperty(ref readedPassword, value);
        }

        public LoginViewModel(IUserService userService, IAppState appState, IHorseService horseService, IShareHorseServices shareHorseServices)
        {
            _userService = userService;
            _appState = appState;
            _horseService = horseService;
            _shareHorseServices = shareHorseServices;

            LoginCommand = new Command(() =>
            {
                if (string.IsNullOrWhiteSpace(ReadedLogin) && string.IsNullOrWhiteSpace(ReadedPassword))
                    return;
                var hashedPassword = ReadedPassword;
                var user = _userService.GetUser(ReadedLogin, hashedPassword);
                if (user == null)
                {
                    IncorrectData();
                    return;
                }
                _appState.CurrentUser = user;
                GoToTheApp();
            });
        }

        public void CheckLogin()
        {
            if (Preferences.Get(PreferencesKeys.UserID, 0) != 0)
            {
                _appState.CurrentUser = _userService.GetLoggedUser(Preferences.Get(PreferencesKeys.UserID, 0));
                GoToTheApp();
            }
        }

        public void IncorrectData()
        {
            WrongData = true;
            OnPropertyChanged(nameof(WrongData));
        }

        private byte[] GenerateSalt(int length)
        {
            var bytes = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            return bytes;
        }

        private byte[] GenerateHash(byte[] password, byte[] salt, int iterations, int length)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return deriveBytes.GetBytes(length);
            }
        }

        public void GoToTheApp()
        {
            Preferences.Set(PreferencesKeys.UserID, _appState.CurrentUser.Id);
            var horseList = _horseService.GetHorsesForUser();
            if (ListServices.IsAny(horseList))
            {
                App.Current.MainPage.DisplayAlert("Uwaga", "Nie posiadasz żadnych koni! Poproś administratora o dodanie koni", "Dobrze");
                return;
            }
            _appState.HorseList = horseList;
            _appState.CurrentHorse = horseList.First();
            App.Current.MainPage = new AppShell();
        }
    }
}