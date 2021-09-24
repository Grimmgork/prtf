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

		private static DataSentinel singleton = new DataSentinel();

	    private DataSentinel(){ }

		public static void ConnectToDatabase(string connectionString, string dbname)
		{	
			singleton.mongoClient = new MongoClient(connectionString.ToString());
			singleton.db = singleton.mongoClient.GetDatabase(dbname);
		}

		public static void DeleteAsset(string ticker)
		{
			ticker = ticker.ToUpper();
			var filter = Builders<Asset>.Filter.Eq("_id", ticker);
			singleton.db.GetCollection<Asset>("assets").DeleteOne(filter);
		}

		public static Asset[] GetAssets()
		{
			return singleton.db.GetCollection<Asset>("assets").Find(new BsonDocument()).ToList().ToArray();
		}

		public static Asset GetAsset(string asset)
		{
			asset = asset.ToUpper();
			var filter = Builders<Asset>.Filter.Eq("_id", asset);
			List<Asset> found = singleton.db.GetCollection<Asset>("assets").Find(filter).ToList();
			if (found.Count == 0)
				return null;
			return found[0];
		}

		public static void InsertAsset(Asset asset)
		{
			asset.ticker = asset.ticker.ToLower();
			singleton.db.GetCollection<Asset>("assets").InsertOne(asset);
		}
	}
}