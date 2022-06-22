using System;
using Newtonsoft.Json;

namespace DapperAlternatives
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataLayer = new DataLayer();

            Console.WriteLine("Pinging...");

            var authDetail = dataLayer.Ping();

            Console.WriteLine(JsonConvert.SerializeObject(authDetail));

            Console.ReadLine();

        }
    }
}
