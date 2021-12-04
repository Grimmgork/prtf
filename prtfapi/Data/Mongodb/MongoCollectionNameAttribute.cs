using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prtfapi.Data.Mongodb
{
	public class MongoCollectionNameAttribute : System.Attribute
	{
		public string collectionName { get; init; }
		
		public MongoCollectionNameAttribute(string _collectionName)
		{
			collectionName = _collectionName;
		}
	}
}
