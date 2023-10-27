using HorseTrackingDesktop.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Database.CalendarService
{
    public interface ICalendarService
    {
        Task<IEnumerable<Events>> GetNearestData();
    }
}