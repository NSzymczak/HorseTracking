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

namespace HorseTrackingDesktop.ViewModel
{
    public partial class LoginViewModel:INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


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
        public void LoggIn()
        {
                var view = new MainView();
                view.Show();
        }

    }
}
