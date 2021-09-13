using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prtfapi
{
	interface IPriceDataProvider
	{
		public PriceCandlestick GetPrice();
	}

	public struct PriceCandlestick
	{
		double max;
		double min;
		double start;
		double end;

		DateTime endTime;
	}
}
