using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SharpdactylLib.Models.Client;

namespace SharpDactyl.Cons
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SharpdactylLib.SharpDactyl test = new SharpdactylLib.SharpDactyl("https://panel.pcbyte.eu", "coM5TnrZNTBij1Ptxkc5FPK93JZD5yqUBZ8vPx1B0pZ5x1Bd");
            var result = await test.Application.GetServers();

            if(result.Count > 0){
                foreach (ServerDatum serverDatum in result)
                {
                    Console.WriteLine($"{serverDatum.Attributes.Name} => {serverDatum.Attributes.Uuid}");
                }
            }
            else
            {
                Console.WriteLine($"No results");
            }
            Console.ReadLine();
        }
    }
}
