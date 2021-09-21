using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prtfapi.Portfolio
{
	public struct Asset
	{
		public string ticker { get; init; }
		public string name { get; init; }
		public string description { get; init; }
	}
}
