using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prtfapi.Portfolio;
using prtfapi.Price;
using Newtonsoft.Json;
using MongoDB.Driver;
using System.Security;

namespace prtfapi.Data
{
	public class DataSentinel
	{
		private MongoClient mongoClient;
		private string dbName;

		private static DataSentinel singleton = new DataSentinel();

	    private DataSentinel(){ }

		public static void Connect(string connectionString, string name)
		{
			singleton.dbName = name;
			singleton.mongoClient = new MongoClient(connectionString.ToString());

			List<string> names = singleton.mongoClient.ListDatabaseNames().ToList(); //check the connection/authenftification
			if (!names.Contains(name))
			{
				throw new Exception($"Database '{name}' not found!");
			}

			//TODO check the structure of the database!
		}
	}
}