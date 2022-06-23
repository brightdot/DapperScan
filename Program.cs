using System;
using Newtonsoft.Json;

namespace DapperAlternatives
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dataLayer = new DataLayer();

            Console.WriteLine("Pinging...");

            var authDetail = dataLayer.Ping("'1' = '1'");

            Console.WriteLine(JsonConvert.SerializeObject(authDetail));

            string filter = Console.ReadLine();

            dataLayer.PingAdoNet(filter);

            Console.ReadLine();

        }
    }
}
