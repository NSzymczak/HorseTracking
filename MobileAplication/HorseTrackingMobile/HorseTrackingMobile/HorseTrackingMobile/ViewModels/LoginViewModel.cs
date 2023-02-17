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

namespace HorseTrackingMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(LogIn);
        }

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

        List<User> userList = new List<User>();

        public void CheckLogin()
        {
            userList = DataBaseOperation.GetAllUsers();
            if (Preferences.Get(PreferencesKeys.IsLogged, false))
            {
                User.CurrentUser = DataBaseOperation.GetLoggedUser();
                GoToTheApp();
            }
            else
            {
            }
        }

        public void IncorrectData()
        {
            //IncorrectDataLabel.IsVisible = true;
        }

        private void LogIn()
        {
            if (string.IsNullOrWhiteSpace(ReadedLogin) && string.IsNullOrWhiteSpace(ReadedPassword))
                return;

            var user = userList.Where(x => x.Login == ReadedLogin).ToList();
            if (ListServices.IsAny(user))
            {
                IncorrectData();
                return;
            }

            var correctUser = user.Where(x => x.Password == ReadedPassword).ToList();
            if (ListServices.IsAny(correctUser))
            {
                IncorrectData();
                return;
            }
            User.CurrentUser = correctUser.First();
            GoToTheApp();
        }

        public async void GoToTheApp()
        {
            Preferences.Set(PreferencesKeys.IsLogged, true);
            Preferences.Set(PreferencesKeys.UserID, User.CurrentUser.Id);
            App.Current.MainPage = new AppShell();
        }
    }
}
