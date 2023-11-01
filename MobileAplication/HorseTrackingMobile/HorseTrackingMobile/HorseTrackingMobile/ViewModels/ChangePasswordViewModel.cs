using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services;
using HorseTrackingMobile.Services.AppState;
using HorseTrackingMobile.Services.Database.HorseServices;
using HorseTrackingMobile.Services.Database.UserServices;
using PasswordHashing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HorseTrackingMobile.ViewModels
{
    public class ChangePasswordViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly IAppState _appState;
        public ICommand ChangePasswordCommand { get; }

        public string Title { get; set; } = "Zmiana hasła";
        public bool WrongData { get; set; }

        private string oldPassword;

        public string OldPassword
        {
            get => oldPassword;
            set => SetProperty(ref oldPassword, value);
        }

        private string newPassword;

        public string NewPassword
        {
            get => newPassword;
            set => SetProperty(ref newPassword, value);
        }

        public ChangePasswordViewModel(IUserService userService, IAppState appState)
        {
            _userService = userService;
            _appState = appState;

            ChangePasswordCommand = new Command(async () =>
            {
                if (!(string.IsNullOrWhiteSpace(OldPassword) && string.IsNullOrWhiteSpace(NewPassword)))
                {
                    if (_userService.ChangePassword(_appState.CurrentUser.Id, NewPassword, OldPassword))
                    {
                        await App.Current.MainPage.DisplayAlert("Zmiana hasła", "Zmiana hasła powiodła się", "Dobrze");
                        await Shell.Current.GoToAsync("..");
                        return;
                    }
                }
                IncorrectData();
                return;
            });
        }

        public void IncorrectData()
        {
            WrongData = true;
            OnPropertyChanged(nameof(WrongData));
        }
    }
}