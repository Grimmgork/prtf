using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prtfapi.Data.Mongodb
{
	public class MongoDataContext : IDataContext
	{
		static IMongoDatabase db;
		
		public MongoDataContext(string connectionstring, string dbname)
		{
			db = new MongoClient(connectionstring).GetDatabase(dbname);
		}
		
		public IRepository<T> GetRepository<T>()
		{
			return new MongoRepository<T>(db);
		}
	}
}
