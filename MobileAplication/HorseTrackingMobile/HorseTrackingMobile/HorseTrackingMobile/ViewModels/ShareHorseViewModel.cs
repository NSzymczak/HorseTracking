using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services;
using HorseTrackingMobile.Services.AppState;
using HorseTrackingMobile.Services.Database.HorseServices;
using System;
using System.Collections.ObjectModel;

namespace HorseTrackingMobile.ViewModels
{
    public class ShareHorseViewModel : BaseViewModel
    {
        private readonly IHorseService _horseService;
        private readonly IEncrypt _encrypt;
        private readonly IAppState _appState;

        public ObservableCollection<Horse> Horses { get; set; }
        public DateTime DateNow { get; set; } = DateTime.Now;

        private DateTime _endDate;

        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;

                if (SelectedHorse != null)
                    ShareByQR(SelectedHorse.ID.ToString(), EndDate);
            }
        }

        private Horse _selectedHorse;

        public Horse SelectedHorse
        {
            get
            {
                return _selectedHorse;
            }
            set
            {
                _selectedHorse = value;
                OnPropertyChanged(nameof(SelectedHorse));
                if (SelectedHorse != null)
                    ShareByQR(SelectedHorse.ID.ToString(), EndDate);
            }
        }

        private string _barcodeValue = "placeholder";

        public string BarcodeValue
        {
            get { return _barcodeValue; }
            set
            {
                _barcodeValue = value;
                OnPropertyChanged(nameof(BarcodeValue));
            }
        }

        public void Load()
        {
            var list = _horseService.GetHorses(_appState.CurrentUser.Id.ToString());
            if (list == null)
                return;

            Horses = new ObservableCollection<Horse>(list);
            OnPropertyChanged(nameof(Horses));

            if (Horses.Count > 0)
                SelectedHorse = Horses[0];
        }

        public ShareHorseViewModel(IHorseService horseService, IEncrypt encrypt, IAppState appState)
        {
            _horseService = horseService;
            _appState = appState;
            _encrypt = encrypt;

            EndDate = DateTime.Now;
        }

        public void ShareByQR(string horseID, DateTime endDate)
        {
            var text = horseID + ";" +
                       endDate.ToShortDateString();

            BarcodeValue = _encrypt.EncryptText(text);
        }
    }
}