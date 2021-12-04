using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prtfapi.Data.Mongodb;
using MongoDB.Bson.Serialization.Attributes;

namespace prtfapi.Portfolio
{
	[MongoCollectionName("assets")]
	public class Asset
	{
		[BsonId]
		public Guid id{ get; init; }
		public string ticker { get; init; }
		public string name { get; init; }
		public string description { get; init; }
		public string[] tags { get; init; }
	}
}