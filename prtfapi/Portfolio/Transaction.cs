using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prtfapi.Portfolio
{
	public interface ITransaction
	{
		public DateTime time { get; }
	}

	public struct Swap : ITransaction
	{
		public DateTime time => throw new NotImplementedException();
	}

	public struct Move
	{
		
	}
}