using DapperAlternatives.Model;

namespace DapperAlternatives
{
    public class DataLayer
    {
        public PingResult Ping(string filter)
        {
            var sql = $"SELECT 1 AS [Result] Where {filter}";
            return DapperExtensions.GetFirstOrDefault<PingResult>(sql);
        }

    }
}
