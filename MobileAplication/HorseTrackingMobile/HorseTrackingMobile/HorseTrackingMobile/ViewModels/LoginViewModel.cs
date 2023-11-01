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
using PasswordHashing;

namespace HorseTrackingMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly IAppState _appState;
        private readonly IHorseService _horseService;
        public ICommand LoginCommand { get; }

        public string Title { get; set; } = "Logowanie";
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

        public LoginViewModel(IUserService userService, IAppState appState, IHorseService horseService)
        {
            _userService = userService;
            _appState = appState;
            _horseService = horseService;

            LoginCommand = new Command(() =>
            {
                if (string.IsNullOrWhiteSpace(ReadedLogin) && string.IsNullOrWhiteSpace(ReadedPassword))
                    return;
                var user = _userService.GetUser(ReadedLogin);
                if (user != null)
                {
                    if (PasswordHasher.Validate(ReadedPassword, user.Hash))
                    {
                        _appState.CurrentUser = user;
                        GoToTheApp();
                        return;
                    }
                }

                IncorrectData();
                return;
            });
        }

        public void CheckLogin()
        {
            var id = Preferences.Get(PreferencesKeys.UserID, 0);
            if (id != 0)
            {
                var user = _userService.GetLoggedUser(id);
                if (user != null)
                {
                    _appState.CurrentUser = user;
                    GoToTheApp();
                }
            }
        }

        public void IncorrectData()
        {
            WrongData = true;
            OnPropertyChanged(nameof(WrongData));
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