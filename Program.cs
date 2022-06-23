using System;
using System.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace DapperAlternatives
{
    internal class Program
    {
        public static readonly string EXASCALE_CONNECTIONSTRING = ConfigurationManager.ConnectionStrings["ExascaleDB"].ConnectionString;
        static void Main(string[] args)
        {
            var dataLayer = new DataLayer();

            Console.WriteLine("Pinging...");

            var authDetail = dataLayer.Ping("'1' = '1'");

            string filter = "'1'='1'";
            var sql = $"SELECT 1 AS [Result] Where {args}";

            Console.WriteLine(JsonConvert.SerializeObject(authDetail));


            using (var connection = new SqlConnection(EXASCALE_CONNECTIONSTRING))
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                int rows = cmd.ExecuteNonQuery();

                connection.Close();
                Console.WriteLine("No of rows affected:" + rows);
            }

            Console.ReadLine();

        }
    }
}
