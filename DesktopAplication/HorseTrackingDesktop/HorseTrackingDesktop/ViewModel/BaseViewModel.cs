using HorseTrackingDesktop.Enumerable;
using HorseTrackingDesktop.Services.AppState;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HorseTrackingDesktop.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private readonly IAppState _appState;
        private string userType;

        public BaseViewModel()
        {
        }

        public BaseViewModel(IAppState appState)
        {
            _appState = appState;
            userType = _appState.CurrentUser.Type.TypeName;
        }

        public bool? IsAdmin
        {
            get => userType == UserTypesEnum.admin.ToString();
        }

        public bool? IsHorseOwner
        {
            get => userType == UserTypesEnum.horseOwner.ToString();
        }

        public bool? IsTrainer
        {
            get => userType == UserTypesEnum.trainer.ToString();
        }

        #region INotify

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotify

        protected bool SetProperty<T>(ref T backingStore, T value,
           [CallerMemberName] string propertyName = "",
           Action? onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}