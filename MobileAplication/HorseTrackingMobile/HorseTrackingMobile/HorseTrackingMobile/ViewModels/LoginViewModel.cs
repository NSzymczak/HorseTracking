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
using HorseTrackingMobile.Database.UserServices;

namespace HorseTrackingMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        List<User> userList = new List<User>();

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

        IUserService _userService;

        public LoginViewModel(IUserService userService)
        {
            _userService = userService;

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
                User.CurrentUser = user.First();

                GoToTheApp();
            });
        }
        public void CheckLogin()
        {
            if (Preferences.Get(PreferencesKeys.IsLogged, false))
            {
                User.CurrentUser = _userService.GetLoggedUser();
                GoToTheApp();
            }
        }

        public void IncorrectData()
        {
            //IncorrectDataLabel.IsVisible = true;
        }

        public void GoToTheApp()
        {
            Preferences.Set(PreferencesKeys.IsLogged, true);
            Preferences.Set(PreferencesKeys.UserID, User.CurrentUser.Id);
            App.Current.MainPage = new AppShell();
        }
    }
}
