using HorseTrackingDesktop.Dto;
using HorseTrackingDesktop.Models;
using HorseTrackingDesktop.Services.AppState;
using HorseTrackingDesktop.Services.Database.HorseService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Database.CalendarService
{
    public class CalendarService : ICalendarService
    {
        private readonly HorseTrackingContext _context;
        private readonly IHorseService _horseService;

        public CalendarService(HorseTrackingContext context, IHorseService horseService)
        {
            _context = context;
            _horseService = horseService;
        }

        public async Task<IEnumerable<Events>> GetNearestData()
        {
            var listOfEvents = new List<Events>();

            var horses = (await _horseService.GetHorses()).Select(x => x.HorseId);
            var visits = _context.Visits.Include(x => x.Professional).ThenInclude(x => x.Detail)
                .Include(x => x.Professional).ThenInclude(x => x.Specialisation).Include(x => x.Horse)
                .Where(x => horses.Contains(x.HorseId));

            foreach (var visit in visits)
            {
                listOfEvents.Add(new Events
                {
                    Data = visit.VisitDate.Date,
                    Name = $"{visit.Professional.Specialisation.Name}, {visit.Professional.Detail.Name} {visit.Professional.Detail.Surname} - {visit.Horse.Name}"
                });
            }

            var activities = _context.Activities.Include(x => x.Horse).Where(x => horses.Contains(x.HorseId));
            foreach (var activity in activities)
            {
                var result = ActivityType.ActivityTypeIdMap.TryGetValue(activity.ActivityType, out var type);
                if (result)
                    listOfEvents.Add(new Events
                    {
                        Data = activity.Date,
                        Name = $"{type?.Name} - {activity.Horse.Name}"
                    });
            }

            var competitions = _context.Competitions;
            foreach (var competition in competitions)
            {
                listOfEvents.Add(new Events
                {
                    Data = competition.Date,
                    Name = $"Zawody - {competition.Rank} {competition.Spot}"
                });
            }
            return listOfEvents.OrderByDescending(x => x.Data);
        }
    }
}