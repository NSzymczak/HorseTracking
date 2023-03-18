using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HorseTrackingMobile.Database
{
    public class DataBaseConnection
    {
        static string dbName = "HorseTracking";
        static string serverName = "tcp:192.168.88.249,1433"; //ipv4 sieci serwera
        static string serverUserName = "Natka";
        static string serverPassword = "123456";
        static string connectionString = $"Data Source={serverName}; Initial Catalog={dbName}; User id={serverUserName}; Password={serverPassword}; Connection Timeout = 10; MultipleActiveResultSets=true";
        public static void Connect()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                App.Current.MainPage.DisplayAlert("Działa", "OK", "OK");

            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Błąd", ex.Message, "OK");
            }
        }
    }
}
