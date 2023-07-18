using HorseTrackingDesktop.Services;
using HorseTrackingDesktop.View;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using HorseTrackingDesktop.Services.AppState;
using System.Windows.Input;
using HorseTrackingDesktop.Services.Database.UserService;
using System.Threading.Tasks;
using HorseTrackingDesktop.Models;

namespace HorseTrackingDesktop.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly IAppState _appState;
        private readonly IUserServices _userService;

        private string? _userLogin;
        public string? UserLogin
        {
            get => _userLogin;
            set => SetProperty(ref _userLogin, value);
        }

        private string? _userHash;
        public string? UserHash
        {
            get => _userHash;
            set => SetProperty(ref _userHash, value);
        }
        public LoginViewModel(IAppState appState, IUserServices userServices)
        {
            _appState = appState;
            _userService = userServices;

        }

        [RelayCommand]
        public async Task CheckLogin()
        {
            if (!String.IsNullOrEmpty(UserLogin) && !String.IsNullOrEmpty(UserHash))
            {
                var user = await _userService.GetUser(UserLogin, UserHash);
                if (user == null)
                {
                    await IncorrectData();
                    return;
                }
                await LogIn(user);
            }
        }

        public Task LogIn(UserAcounts user)
        {
            _appState.CurrentUser = user;
            new MainView().Show();
            return Task.CompletedTask;
        }

        public Task IncorrectData()
        {

            return Task.CompletedTask;
        }

    }
}
