using HorseTrackingDesktop.Enumerable;
using HorseTrackingDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingDesktop.Services.Database.HorseService
{
    public interface IHorseService
    {
        public Task<List<Horses>> GetHorses();
    }
}
