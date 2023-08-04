using CommunityToolkit.Mvvm.Input;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.Database.VisitService;
using HorseTrackingDesktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using HorseTrackingDesktop.Models.Dto;

namespace HorseTrackingDesktop.PageModel.Management
{
    internal partial class ProfessionalManagementPageModel : BaseViewModel
    {
        private readonly IVisitService _visitService;
        public ProfessionalsDto CurrentProfessional { get; set; }

        public List<ProfessionalsDto> Professionals { get; set; }

        public List<Specialisations> Specialisations { get; set; }

        public ProfessionalManagementPageModel(IVisitService visitService)
        {
            _visitService = visitService;
        }

        public async Task SetUp()
        {
            await GetProfessional();
            if (Professionals.Count > 0)
            {
                CurrentProfessional = Professionals.First();
            }
            Specialisations = await _visitService.GetSpecialisations();
            OnPropertyChanged(nameof(Professionals));
            OnPropertyChanged(nameof(CurrentProfessional));
            OnPropertyChanged(nameof(Specialisations));
        }

        public async Task GetProfessional()
        {
            Professionals = (await _visitService.GetProfessionals(true)).Select(ProfessionalsDto.Convert).ToList();
        }

        [RelayCommand]
        public async Task Remove()
        {
            if (CurrentProfessional != null)
            {
                await _visitService.RemoveProfessionalDate(ProfessionalsDto.ConvertBack(CurrentProfessional));
            }
            await GetProfessional();
        }

        public async Task Add(ProfessionalsDto professionals)
        {
            if (professionals.ID == 0)
            {
                await _visitService.AddProfessional(ProfessionalsDto.ConvertBack(professionals));
            }
            else
            {
                await _visitService.EditProfessional(ProfessionalsDto.ConvertBack(professionals));
            }
        }
    }
}