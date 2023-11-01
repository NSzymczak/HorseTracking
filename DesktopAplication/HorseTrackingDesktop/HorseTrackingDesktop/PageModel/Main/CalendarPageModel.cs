using HorseTrackingDesktop.Dto;
using HorseTrackingDesktop.Services.Database.CalendarService;
using HorseTrackingDesktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.PageModel.Main
{
    public class CalendarPageModel : BaseViewModel
    {
        private readonly ICalendarService _calendarService;
        public ObservableCollection<Events>? ListOfEvents { get; set; }

        public CalendarPageModel(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        public async Task Load()
        {
            ListOfEvents = new ObservableCollection<Events>(await _calendarService.GetNearestData());
            OnPropertyChanged(nameof(ListOfEvents));
        }
    }
}