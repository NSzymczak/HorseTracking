using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HorseTrackingMobile.Services.Database
{
    public class ConnectionService : IConnectionService
    {
        private static string dbName = "HorseTracking";
        private static string serverName = "tcp:192.168.88.244,1433"; //Głuchołazy
                                                                      //private static string serverName = "tcp:192.168.1.19,1433"; //Opole
                                                                      //private static string serverName = "tcp:10.1.1.107,1433"; //Studia
                                                                      //private static string serverName = "tcp:192.168.10.118,1433"; //Kondradów
                                                                      //private static string serverName = "tcp:192.168.1.7,1433"; //Olesno

        private static string serverUserName = "Natka";
        private static string serverPassword = "123456";
        private static string connectionString = $"Data Source={serverName}; Initial Catalog={dbName}; User id={serverUserName}; Password={serverPassword}; Connection Timeout = 10; MultipleActiveResultSets=true";

        public SqlConnection SqlConnection;

        public void Connect()
        {
            if (SqlConnection == null)
                SqlConnection = new SqlConnection(connectionString);

            if (SqlConnection.State == System.Data.ConnectionState.Open) return;

            try
            {
                SqlConnection.Open();
                if (SqlConnection.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connection open!");
            }
            catch
            {
            }
        }

        public SqlConnection GetConnection()
        {
            Connect();
            return SqlConnection;
        }
    }
}