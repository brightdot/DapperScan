using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DapperAlternatives
{
    public static class DapperExtensions
    {
        public static readonly string EXASCALE_CONNECTIONSTRING = ConfigurationManager.ConnectionStrings["ExascaleDB"].ConnectionString;

        public static IReadOnlyList<T> GetAll<T>(string sql, object parameters = null)
        {
            using (var connection = new SqlConnection(EXASCALE_CONNECTIONSTRING))
            {
                connection.Open();
                return connection.GetAll<T>(sql, parameters);
            }
        }

        public static T GetFirstOrDefault<T>(string sql, object parameters = null)
        {
            using (var connection = new SqlConnection(EXASCALE_CONNECTIONSTRING))
            {
                connection.Open();
                return connection.GetFirstOrDefault<T>(sql, parameters);
            }
        }

        public static int Execute(string sql, object parameters = null)
        {
            using (var connection = new SqlConnection(EXASCALE_CONNECTIONSTRING))
            {
                connection.Open();
                return connection.Execute(sql, parameters);
            }
        }

        public static int Execute(string sql, SqlConnection connection, SqlTransaction transaction, object parameters = null)
        {
            return connection.Execute(sql, parameters, transaction: transaction);
        }

        public static List<T3> Query<T1, T2, T3>(string sql, Func<T1, T2, T3> func, string splitOn)
        {
            using (var connection = new SqlConnection(EXASCALE_CONNECTIONSTRING))
            {
                connection.Open();
                return connection.Query(sql, func, splitOn: splitOn).ToList();
            }
        }

        public static (List<T1>, List<T2>) QueryMultiple<T1, T2>(string sql, object parameters = null)
        {
            using (var connection = new SqlConnection(EXASCALE_CONNECTIONSTRING))
            {
                connection.Open();
                var result = connection.QueryMultiple(sql, parameters);

                var result1 = result.Read<T1>().ToList();

                var result2 = result.Read<T2>().ToList();

                return (result1, result2);
            }
        }

        public static T GetFirstOrDefault<T>(this SqlConnection connection, string sql, object parameters = null) => connection.QueryFirstOrDefault<T>(sql, parameters);

        public static IReadOnlyList<T> GetAll<T>(this SqlConnection connection, string sql, object parameters = null) => connection.Query<T>(sql, parameters).ToList();
    }
}
