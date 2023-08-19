using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IAppState _appState;
        private string userType;

        public MainViewModel(IAppState appState) : base(appState)
        {
            _appState = appState;
            userType = _appState.CurrentUser.Type.TypeName;
        }

        private bool? _isAdmin;

        public bool? IsAdmin
        {
            get => userType == "admin";
        }
    }
}