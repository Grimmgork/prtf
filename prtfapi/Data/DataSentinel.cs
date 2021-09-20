using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prtfapi.Portfolio;
using prtfapi.Price;
using Newtonsoft.Json;
using MongoDB.Driver;
using System.IO;

namespace prtfapi.Data
{
	public class DataSentinel
	{
		public Config config;
		public MongoClient dbClient;

		public DataSentinel()
		{
			Directory.SetCurrentDirectory( Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName );
			string configFilePath = Directory.GetCurrentDirectory() + "\\config.json";
			if (File.Exists(configFilePath)) {
				config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(configFilePath));
			}
			else{
				config = new Config() { dbConnectionString = "mongodb://localhost:27017"};
				File.WriteAllText(configFilePath, JsonConvert.SerializeObject(config));
				Console.WriteLine("No config found, created a new one!");
			}

			Console.WriteLine("Config loadet!");
			Console.WriteLine("Connecting to " + config.dbConnectionString + " ...");
		}


		public PriceCandlestick[] GetPriceData(PriceProvider provider, DateTime start, DateTime end)
		{	
			return null;
		}

		public ITransaction[] GetTransactions()
		{
			return null;
		}



		public void StorePriceData(PriceCandlestick[] data)
		{
			
		}

		public void StoreTransaction()
		{
			
		}

		
		public struct Config
		{
			public string dbConnectionString { get; init; }
		}
	}
}