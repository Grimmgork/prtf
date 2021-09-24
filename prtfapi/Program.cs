using Microsoft.AspNetCore.Hosting;
using System.Text;
using System;
using System.IO;
using prtfapi.Data;
using Newtonsoft.Json;
using prtfapi.Portfolio;

namespace prtfapi
{
    class Program
    {
        public static Config config;

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
            Console.WriteLine("by Eric Armbruster");
            Console.WriteLine();

            //load config
            Directory.SetCurrentDirectory(Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName);
            string configFilePath = Directory.GetCurrentDirectory() + "\\prtfapi.cfg";
            if (File.Exists(configFilePath))
            {
                config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(configFilePath));
            }
            else
            {
                config = new Config() { dbConnectionString = "mongodb://localhost:27017", url="http://0.0.0.0:5000", dbName="portfolio"};
                File.WriteAllText(configFilePath, JsonConvert.SerializeObject(config));
                Console.WriteLine("No config found, created a new one!");
            }

            //connect to database
            DataSentinel.ConnectToDatabase(config.dbConnectionString, config.dbName);
            Console.WriteLine("Database authentification successful!");

            //starting REST API
            Console.WriteLine("Starting kestrel ...");
            var host = new WebHostBuilder()
            .UseKestrel()
            .UseStartup<Startup>()
            .UseUrls(new string[] { config.url })
            .Build();

            host.Run();
        }
    }

    public struct Config
    {
        public string dbConnectionString { get; init; }
        public string url { get; init; }
        public string dbName { get; init; }
    }
}
