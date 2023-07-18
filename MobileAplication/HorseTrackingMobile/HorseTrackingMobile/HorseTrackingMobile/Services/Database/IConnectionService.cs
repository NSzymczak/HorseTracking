using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HorseTrackingMobile.Services.Database
{
    public interface IConnectionService
    {
        SqlConnection GetConnection();
    }
}
