using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace prtfapi.Portfolio
{
	public class Asset
	{
		[BsonId]
		public string ticker{ get; set; }

		public string name { get; set; }
		public string description { get; set; }
		public string[] tags { get; set; }
	}
}
