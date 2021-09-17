using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prtfapi.Price
{
	public struct PriceProvider
	{
		public string assetId;
		public string path;
		public bool dbCache;

		public string[] extendetParameters;
	}
}