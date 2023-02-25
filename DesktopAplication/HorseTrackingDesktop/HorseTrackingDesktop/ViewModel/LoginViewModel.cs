using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.ViewModel
{
    public class LoginViewModel:INotifyPropertyChanged
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

        public void LoggIn()
        {
            if (_userLogin == null) { return; }
            if(_userHash== null) { return; }


        }

    }
}
