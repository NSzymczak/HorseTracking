using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.Database.HorseService;
using HorseTrackingDesktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Management.PageModel
{
    public class HorseManagmentPageModel : BaseViewModel
    {
        private readonly IHorseService _horseService;

        public List<Horses> Horses
        {
            get;
            set;
        }

        public List<Status> AvailableStatus { get; set; }
        public List<HorseGenders> AvailableGenders { get; set; }

        public HorseManagmentPageModel(IHorseService horseService)
        {
            _horseService = horseService;
        }

        public async Task GetHorses()
        {
            Horses = await _horseService.GetHorses();
            AvailableStatus = await _horseService.GetStatus();
            AvailableGenders = await _horseService.GetGenders();
            OnPropertyChanged(nameof(AvailableGenders));
            OnPropertyChanged(nameof(AvailableStatus));
            OnPropertyChanged(nameof(Horses));
        }
    }
}