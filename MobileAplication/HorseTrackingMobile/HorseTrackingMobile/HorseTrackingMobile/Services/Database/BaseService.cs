using HorseTrackingMobile.Services.Database;
using System.Data.SqlClient;

namespace HorseTrackingMobile.Database
{
    public class BaseDataService
    {
        private IConnectionService _connectionService;
        protected static SqlConnection sqlConnection;

        public BaseDataService(IConnectionService connectionServices)
        {
            _connectionService = connectionServices;
            sqlConnection = _connectionService.GetConnection();
        }
    }
}
