using Microsoft.AspNetCore.Hosting;
using System.Text;
using System;
using prtfapi.Data;

namespace prtfapi
{
    class Program
    {
        public static DataSentinel provider;    

        static void Main(string[] args)
        {
            Console.WriteLine("██████╗ ██████╗ ████████╗███████╗");
            Console.WriteLine("██╔══██╗██╔══██╗╚══██╔══╝██╔════╝");
            Console.WriteLine("██████╔╝██████╔╝   ██║   █████╗  ");
            Console.WriteLine("██╔═══╝ ██╔══██╗   ██║   ██╔══╝  ");
            Console.WriteLine("██║     ██║  ██║   ██║   ██║     ");
            Console.WriteLine("╚═╝     ╚═╝  ╚═╝   ╚═╝   ╚═╝     ");
            Console.WriteLine();
            Console.WriteLine("A portfolio- tracking RESTFUL API");
            Console.WriteLine("(c) Eric Armbruster");
            Console.WriteLine();

            provider = new DataSentinel();

            Console.WriteLine();
            Console.WriteLine("Starting kestrel ...");
            var host = new WebHostBuilder()
            .UseKestrel()
            .UseStartup<Startup>()
            .UseUrls(new string[] { "http://0.0.0.0:5000" })
            .Build();

            host.Run();
        }
    }
}
