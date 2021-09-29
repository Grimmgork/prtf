using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prtfapi.Portfolio;
using prtfapi.Price;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;

namespace prtfapi.Data
{
	public class DataSentinel
	{
		private MongoClient mongoClient;
		private IMongoDatabase db;
		private IMongoCollection<Asset> assets;

		private static DataSentinel singleton = new DataSentinel();

	    private DataSentinel(){ }

		public static void ConnectToDatabase(string connectionString, string dbname)
		{	
			singleton.mongoClient = new MongoClient(connectionString.ToString());
			singleton.db = singleton.mongoClient.GetDatabase(dbname);
			singleton.assets = singleton.db.GetCollection<Asset>("assets");
		}

		public static void DeleteAsset(string ticker)
		{
			var filter = Builders<Asset>.Filter.Eq("_id", ticker.ToLower());
			singleton.assets.DeleteOne(filter);
		}

		public static Asset[] GetAssets()
		{
			var filter = new BsonDocument();
			return singleton.assets.Find(filter).ToList().ToArray();
		}

		public static Asset GetAsset(string ticker)
		{
			var filter = Builders<Asset>.Filter.Eq("_id", ticker.ToLower());
			List<Asset> found = singleton.assets.Find(filter).ToList();
			if (found.Count == 0)
				return null;
			return found[0];
		}

		public static void InsertAsset(Asset asset)
		{
			singleton.assets.InsertOne(asset);
		}
	}
}