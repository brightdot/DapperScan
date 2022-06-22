using DapperAlternatives.Model;

namespace DapperAlternatives
{
    public class DataLayer
    {
        public PingResult Ping()
        {
            var sql = @"SELECT 1 AS [Result]";
            var parameters = new
            {
                PhoneNumber = "12345678"
            };
            return DapperExtensions.GetFirstOrDefault<PingResult>(sql, parameters);
        }

    }
}
