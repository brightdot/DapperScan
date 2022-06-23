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

            string filter = "'1'='1'";


            Console.WriteLine(JsonConvert.SerializeObject(authDetail));

            dataLayer.PingAdoNet(args);

            Console.ReadLine();

        }
    }
}
