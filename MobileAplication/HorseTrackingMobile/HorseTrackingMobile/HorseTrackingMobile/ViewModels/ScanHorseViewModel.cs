using HorseTrackingMobile.Models;
using HorseTrackingMobile.Services;
using HorseTrackingMobile.Services.AppState;
using HorseTrackingMobile.Services.Database.HorseServices;
using HorseTrackingMobile.Services.Database.ShareHorseServices;
using HorseTrackingMobile.Services.Database.UserServices;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;
using static System.Net.Mime.MediaTypeNames;

namespace HorseTrackingMobile.ViewModels
{
    public class ScanHorseViewModel : BaseViewModel
    {
        private readonly IEncrypt _encrypt;
        private readonly IHorseService _horseService;
        private readonly IShareHorseServices _shareHorseServices;
        private readonly IAppState _appState;
        private readonly IUserService _userService;

        private Horse shareHorse;
        private DateTime endTime;
        private string scanUser;
        private string shareUser;

        public ICommand ScanCommand { get; set; }
        public bool IsScanning { get; set; } = true;

        public ScanHorseViewModel(IEncrypt encrypt, IHorseService horseService,
            IShareHorseServices shareHorseServices, IAppState appState,
            IUserService userService, IAppShellRoutingService appShellRoutingService)
        {
            _encrypt = encrypt;
            _horseService = horseService;
            _shareHorseServices = shareHorseServices;
            _appState = appState;
            _userService = userService;
        }

        public async Task Scan(string text)
        {
            IsScanning = false;
            OnPropertyChanged(nameof(IsScanning));
            _shareHorseServices.DelateOutdated();

            var decodedText = _encrypt.DecryptText(text);
            if (decodedText == "placeholder")
            {
                await Shell.Current.GoToAsync("..");
            }

            var result = EncodedData(decodedText);
            if (result)
            {
                if (_shareHorseServices.CheckShared(shareHorse.ID.ToString()) &&
                    endTime > DateTime.Now)
                {
                    SaveShare();
                }
            }
            await Shell.Current.GoToAsync("..");
        }

        public bool EncodedData(string text)
        {
            var data = text.Split(';');
            try
            {
                if (data.Length != 2)
                {
                    return false;
                }

                var endDate = data[1];
                endTime = DateTime.Parse(endDate);

                var horseID = data[0];
                if (horseID == String.Empty || horseID == null)
                    return false;
                shareHorse = _horseService.GetHorse(horseID);
                if (shareHorse == null)
                {
                    return false;
                }
                shareUser = _userService.GetHorseOwner(horseID)?.Id.ToString();
                if (shareUser == null)
                {
                    return false;
                }
                scanUser = _appState.CurrentUser.Id.ToString();
                if (scanUser == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void SaveShare()
        {
            _shareHorseServices.SaveShareFromQR(shareHorse.ID.ToString(), DateTime.Now, endTime, scanUser, shareUser);
        }
    }
}