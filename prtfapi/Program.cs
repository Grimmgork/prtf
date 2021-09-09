using Microsoft.AspNetCore.Hosting;
using System.Text;
using System;

namespace prtf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("                                       /%/   ");
            Console.WriteLine("                          @@@,.     @@@@&&@%*");
            Console.WriteLine(" %%%  &@@@.     %%%   #@/%%@@@@&%% %@@@@@&%  ");
            Console.WriteLine(" @@@@@@@@@@@@,  @@@@@@@@@@&@@@@@@@%&@@@@@@@%/");
            Console.WriteLine(" @@@%(.  ,@@@#, @@@&#*.... @@@%*    &@@@%,   ");
            Console.WriteLine(" @@@%(   .@@@%* @@@%(      @@@%*    &@@@%,   ");
            Console.WriteLine(" @@@@(  @@@@%#, @@@%(      @@@@/ *  &@@@%,   ");
            Console.WriteLine(" @@@%@@@@@%%(.  @@@%(       *@@@@@%*&@@@%,   ");
            Console.WriteLine(" @@@%(                                       ");
            Console.WriteLine("  (%%(                                       ");

            Console.WriteLine();
            Console.WriteLine("A portfolio- tracking RESTFUL API");
            Console.WriteLine("(c) Eric Armbruster");
            Console.WriteLine();

            var host = new WebHostBuilder()
            .UseKestrel()
            .UseStartup<Startup>()
            .UseUrls(new string[] { "http://0.0.0.0:5000" })
            .Build();

            host.Run();
        }
    }
}
