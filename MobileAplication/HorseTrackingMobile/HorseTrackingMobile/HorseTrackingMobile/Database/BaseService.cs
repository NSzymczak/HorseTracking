using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HorseTrackingMobile.Database
{
    public class BaseService
    {
        private IConnectionService _connectionService;
        protected static SqlConnection sqlConnection;

        public BaseService(IConnectionService connectionServices)
        {
            _connectionService = connectionServices;
            sqlConnection = _connectionService.GetConnection();
        }
    }
}
