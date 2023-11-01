using HorseTrackingMobile.Services;
using HorseTrackingMobile.Services.AppState;
using HorseTrackingMobile.Services.Database.ShareHorseServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HorseTrackingMobile.ViewModels
{
    public class ShareManagmentViewModel
    {
        private readonly IAppShellRoutingService _appShellRoutingService;
        private readonly IShareHorseServices _shareHorseServices;
        private readonly IAppState _appState;
        public ICommand ShareQRCommand { get; set; }
        public ICommand ShareBySearchCommand { get; set; }
        public ICommand ScanQRCommand { get; set; }
        public ICommand CleanShareCommand { get; set; }

        public ShareManagmentViewModel(IAppShellRoutingService appShellRoutingService,
            IShareHorseServices shareHorseServices, IAppState appState)
        {
            _appShellRoutingService = appShellRoutingService;
            _shareHorseServices = shareHorseServices;
            _appState = appState;

            ShareQRCommand = new Command(() =>
            {
                _appShellRoutingService.GoToShareHorses();
            });

            ScanQRCommand = new Command(() =>
            {
                _appShellRoutingService.GoToScanHorses();
            });

            CleanShareCommand = new Command(async () =>
            {
                if (await App.Current.MainPage.DisplayAlert("Uwaga", "Czy chcesz przestać udostępniać wszystkie swoje konie?", "Tak", "Nie", FlowDirection.MatchParent))
                    _shareHorseServices.CleanShare(_appState.CurrentUser.Id.ToString());
            });

            ShareBySearchCommand = new Command(() =>
            {
                _appShellRoutingService.GoToShareBySearch();
            });
        }
    }
}