using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharpdactylLib.Models.Application.Server;

namespace SharpDactyl.Cons
{
    class Program
    {
        static async Task Main()
        {
            SharpdactylLib.SharpDactyl test = new SharpdactylLib.SharpDactyl("[Domain]", "[Application API Key]");
            var result = await test.Application.GetServers();

            if(result.Count > 0){
                foreach (ServerDatum serverDatum in result)
                {
                    string json = JsonConvert.SerializeObject(serverDatum, Formatting.Indented);
                    Console.WriteLine($"{json}\n\n");
                }
            }
            else
            {
                Console.WriteLine($"No results");
            }
        }
    }
}
