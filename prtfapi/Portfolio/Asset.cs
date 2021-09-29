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
		private string _ticker;

		[BsonId]
		public string ticker
		{
			get
			{
				return _ticker;
			}
			set
			{
				_ticker = value.ToLower();
			}
		}

		public string name { get; set; }
		public string description { get; set; }
		public string[] tags { get; set; }
	}
}
