using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HorseTrackingMobile.Services
{
    public interface IDataStoreActivity<T>
    {        
        Task<bool> AddActivityAsync(T activity);
        Task<bool> UpdateActivityAsync(T activity);
        Task<bool> DeleteActivityAsync(int id);
        Task<T> GetActivityAsync(int id);
        Task<IEnumerable<T>> GetActivitiesAsync(bool forceRefresh = false);
    }
}
