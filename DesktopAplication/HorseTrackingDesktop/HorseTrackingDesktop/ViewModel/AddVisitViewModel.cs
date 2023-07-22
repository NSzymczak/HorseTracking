using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using HorseTrackingDesktop.Services.Database.HorseService;
using HorseTrackingDesktop.Services.Database.VisitService;
using HorseTrackingDesktop.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HorseTrackingDesktop.ViewModel
{
    public partial class AddVisitViewModel : BaseViewModel
    {
        private bool isEdit = false;

        private int visitID;
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

        private double cost;

        public double Cost
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
        private readonly IHorseService _horseService;

        public AddVisitViewModel(IAppState appState, IVisitService visitService,
                                IHorseService horseService)
        {
            _appState = appState;
            _visitService = visitService;
            _horseService = horseService;
        }

        public async Task SetUp()
        {
            Horses = await _horseService.GetHorses();
            Professionals = await _visitService.GetProfessionals();
            OnPropertyChanged(nameof(Professionals));
            OnPropertyChanged(nameof(Horses));
        }

        public void SetVist(Visits visit)
        {
            isEdit = true;
            visitID = visit.VisitId;
            VisitDate = visit.VisitDate;
            Cost = visit.Cost != null ? visit.Cost.Value : 0;
            Horse = visit.Horse;
            Professional = visit.Professional;
            Description = visit.Summary;
        }

        public void SetDefault()
        {
            Horse = Horses.First();
            Professional = Professionals.First();
            VisitDate = DateTime.Now;
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
            if (isEdit)
            {
                _visitService.EditVisit(new Visits()
                {
                    VisitDate = VisitDate,
                    Cost = Cost,
                    Horse = Horse,
                    Professional = Professional,
                    Summary = Description
                }, visitID);
            }
            else
            {
                _visitService.AddVisit(new Visits()
                {
                    VisitDate = VisitDate,
                    Cost = Cost,
                    Horse = Horse,
                    Professional = Professional,
                    Summary = Description
                });
            }
            window.Close();
            return Task.CompletedTask;
        }
    }
}