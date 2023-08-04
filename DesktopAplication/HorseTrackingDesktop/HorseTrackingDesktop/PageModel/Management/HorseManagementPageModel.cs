using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.Database.HorseService;
using HorseTrackingDesktop.Services.Validator;
using HorseTrackingDesktop.View;
using HorseTrackingDesktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace HorseTrackingDesktop.PageModel.Management
{
    public partial class HorseManagmentPageModel : BaseViewModel
    {
        private readonly IHorseService _horseService;
        private readonly IValidator _validator;

        public List<Horses>? Horses { get; set; }

        public List<Status>? AvailableStatus { get; set; }
        public List<HorseGenders>? AvailableGenders { get; set; }

        public Horses? SelectedHorse { get; set; }

        public HorseManagmentPageModel(IHorseService horseService)
        {
            _horseService = horseService;
        }

        public async Task GetHorses()
        {
            Horses = await _horseService.GetAllHorses();
            AvailableStatus = await _horseService.GetStatus();
            AvailableGenders = await _horseService.GetGenders();

            OnPropertyChanged(nameof(AvailableGenders));
            OnPropertyChanged(nameof(AvailableStatus));
            OnPropertyChanged(nameof(Horses));
        }

        [RelayCommand]
        public async Task AddHorse(Horses horse)
        {
            new AddUserForHorseView(horse).ShowDialog();
        }

        [RelayCommand]
        public async Task DeleteHorse()
        {
            if (SelectedHorse == null)
                return;

            var result = MessageBox.Show($"Na pewno chcesz usunąć wybranego konia ({SelectedHorse.Name})?", "Usuń",
                MessageBoxButton.YesNoCancel, MessageBoxImage.Warning, MessageBoxResult.Yes);

            if (result == MessageBoxResult.Yes)
            {
                await _horseService.DeleteHorse(SelectedHorse);
            }

            Horses = await _horseService.GetAllHorses();
            OnPropertyChanged(nameof(Horses));
        }

        [RelayCommand]
        public async Task ChangeUser()
        {
            if (SelectedHorse != null)
                new AddUserForHorseView(SelectedHorse).ShowDialog();
        }

        public bool CellValid(string colName, string textToValide)
        {
            return false;
        }
    }
}