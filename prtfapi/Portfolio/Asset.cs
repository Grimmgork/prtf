using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prtfapi.Data;
using MongoDB.Bson.Serialization.Attributes;

namespace prtfapi.Portfolio
{
	[MongoCollectionName("assets")]
	public class Asset
	{
		[BsonId]
		public string ticker { get; init; }
		public string name { get; init; }
		public string description { get; init; }
		public string[] tags { get; init; }
	}
}