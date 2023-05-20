using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HorseTrackingMobile.Services.Database
{
    public class ConnectionService : IConnectionService
    {
        private static string dbName = "HorseTracking";
        //private static string serverName = "tcp:192.168.88.249,1433"; //Głuchołazy
        //private static string serverName = "tcp:192.168.1.19,1433"; //Opole
        //private static string serverName = "tcp:10.1.0.230,1433"; //Studia
        private static string serverName = "tcp:192.168.10.118,1433"; //Kondradów
        private static string serverUserName = "Natka";
        private static string serverPassword = "123456";
        private static string connectionString = $"Data Source={serverName}; Initial Catalog={dbName}; User id={serverUserName}; Password={serverPassword}; Connection Timeout = 10; MultipleActiveResultSets=true";

        public SqlConnection SqlConnection;

        private void Connect()
        {
            if (SqlConnection != null) return;
            SqlConnection = new SqlConnection(connectionString);
            try
            {
                SqlConnection.Open();
            }
            catch (Exception ex)
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Błąd", ex.Message, "OK");
            }
        }

        public SqlConnection GetConnection()
        {
            Connect();
            return SqlConnection;
        }

    }
}
