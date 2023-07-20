using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using HorseTrackingDesktop.Services.Database.VisitService;
using HorseTrackingDesktop.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HorseTrackingDesktop.ViewModel
{
    public partial class AddVisitViewModel : BaseViewModel
    {
        private DateTime visitDate;
        public DateTime VisitDate
        {
            get => visitDate;
            set => SetProperty(ref visitDate, value);
        }

        private Professionals professional;
        public Professionals Professional
        {
            get => professional;
            set => SetProperty(ref professional, value);
        }

        private Horses horse;
        public Horses Horse
        {
            get => horse;
            set => SetProperty(ref horse, value);
        }

        private float cost;
        public float Cost
        {
            get => cost;
            set => SetProperty(ref cost, value);
        }

        private string description;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        private Image image;
        public Image Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        public List<Professionals> Professionals { get; set; } = new();
        public ICollection<Horses> Horses { get; set; }

        private readonly IAppState _appState;
        private readonly IVisitService _visitService;
        public AddVisitViewModel(IAppState appState, IVisitService visitService)
        {
            _appState = appState;
            _visitService = visitService;
        }

        public async Task SetUp()
        {
            //jakaś metoda pobierająca konie z bazy
            //Horses = _appState.CurrentUser.Horses;
            //Horse = 

            Professionals = await _visitService.GetProfessionals();
            Professional = Professionals.First();

            OnPropertyChanged(nameof(Professionals));
            OnPropertyChanged(nameof(Horses));
        }

        [RelayCommand]
        public Task GoToImage(Window window)
        {
            new ImageView().ShowDialog();
            return Task.CompletedTask;
        }

        [RelayCommand]
        public Task GoBack(Window window)
        {
            window.Close();
            return Task.CompletedTask;
        }

        [RelayCommand]
        public Task Add(Window window)
        {
            window.Close();
            return Task.CompletedTask;
        }
    }
}
