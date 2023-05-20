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

namespace HorseTrackingMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private string readedLogin;
        private string readedPassword;

        public string ReadedLogin
        {
            get => readedLogin;
            set => SetProperty(ref readedLogin, value);
        }

        public string ReadedPassword
        {
            get => readedPassword;
            set => SetProperty(ref readedPassword, value);
        }
        public ICommand LoginCommand { get; }

        private readonly IUserService _userService;
        private readonly IAppState _appState;
        private readonly IHorseService _horseService;
        public LoginViewModel(IUserService userService, IAppState appState, IHorseService horseService)
        {
            _userService = userService;
            _appState = appState;
            _horseService = horseService;

            LoginCommand = new Command(() =>
            {
                if (string.IsNullOrWhiteSpace(ReadedLogin) && string.IsNullOrWhiteSpace(ReadedPassword))
                    return;

                var user = _userService.GetUser(ReadedLogin, ReadedPassword);
                if (ListServices.IsAny(user))
                {
                    IncorrectData();
                    return;
                }
                _appState.CurrentUser = user.First();
                User.CurrentUser = user.First();
                GoToTheApp();
            });
        }
        public void CheckLogin()
        {
            //if (Preferences.Get(PreferencesKeys.IsLogged, false))
            //{
            //    User.CurrentUser = _userService.GetLoggedUser();
            //    GoToTheApp();
            //}
        }

        public void IncorrectData()
        {
            //IncorrectDataLabel.IsVisible = true;
        }

        public void GoToTheApp()
        {
            Preferences.Set(PreferencesKeys.IsLogged, true);
            Preferences.Set(PreferencesKeys.UserID, User.CurrentUser.Id);
            var horseList = _horseService.GetHorses();

            if (ListServices.IsAny(horseList))
            {
                return;
            }
            _appState.HorseList = horseList;
            _appState.CurrentHorse = horseList.First();
            App.Current.MainPage = new AppShell();
        }
    }
}
