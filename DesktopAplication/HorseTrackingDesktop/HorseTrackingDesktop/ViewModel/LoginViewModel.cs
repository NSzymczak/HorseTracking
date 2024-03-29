﻿using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using HorseTrackingDesktop.Services.Database.UserService;
using HorseTrackingDesktop.View;
using PasswordHashing;
using System;
using System.Threading.Tasks;
using System.Windows;

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

        private string? _userPassword;

        public string? UserPassword
        {
            get => _userPassword;
            set => SetProperty(ref _userPassword, value);
        }

        public LoginViewModel(IAppState appState, IUserServices userServices)
        {
            _appState = appState;
            _userService = userServices;
        }

        [RelayCommand]
        public async Task CheckLogin(Window window)
        {
            if (!String.IsNullOrEmpty(UserLogin) && !String.IsNullOrEmpty(UserPassword))
            {
                var user = await _userService.GetUser(UserLogin);
                if (user == null)
                {
                    await IncorrectData();
                    return;
                }
                else
                {
                    if (PasswordHasher.Validate(UserPassword, user.Hash))
                    {
                        await LogIn(user);
                        window.Close();
                    }
                    else
                    {
                        await IncorrectData();
                    }
                }
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
            MessageBox.Show("Nieprawidłowe dane logowania");
            return Task.CompletedTask;
        }
    }
}