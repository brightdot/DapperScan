using System.Configuration;
using System.Data.SqlClient;
using DapperAlternatives.Model;

namespace DapperAlternatives
{
    public class DataLayer
    {
        public static readonly string EXASCALE_CONNECTIONSTRING = ConfigurationManager.ConnectionStrings["ExascaleDB"].ConnectionString;
        public PingResult Ping(string filter)
        {
            var sql = $"SELECT 1 AS [Result] Where {filter}";
            return DapperExtensions.GetFirstOrDefault<PingResult>(sql);
        }

        public int PingAdoNet(string[] args)
        {
            var sql = $"SELECT 1 AS [Result] Where {args}";

            using (var connection = new SqlConnection(EXASCALE_CONNECTIONSTRING))
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                int rows = cmd.ExecuteNonQuery();

                connection.Close();

                return rows;
            }
        }

    }
}
