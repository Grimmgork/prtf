using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prtfapi.Data
{
	public interface IDataContext
	{
		public IRepository<T> GetRepository<T>();
	}
}
