using HorseTrackingDesktop.Services;
using HorseTrackingDesktop.View;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using HorseTrackingDesktop.Models;

namespace HorseTrackingDesktop.ViewModel
{
    public partial class LoginViewModel:BaseViewModel
    {

        private string _userLogin;
        public string UserLogin
        {
            get { return _userLogin; }
            set
            {
                _userLogin = value;
                OnPropertyChanged();
            }
        }

        private string _userHash;
        public string UserHash
        {
            get { return _userHash; }
            set
            {
                _userHash = value;
                OnPropertyChanged();
            }
        }

        [RelayCommand]
        public void LoggIn(Window window)
        {
            UserAcount.CurrentUser.AcountLogin = "admin";
            var view = new MainView();
            view.Show();
            window.Close();
        }

    }
}
