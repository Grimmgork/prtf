using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace prtfapi.Data
{
	public interface IRepository<T>
	{
		public IQueryable<T> All();

		public T WhereOne(Expression<Func<T, bool>> filter);

		public IEnumerable<T> Where(Expression<Func<T, bool>> filter);

		public void RemoveOneWhere(Expression<Func<T, bool>> filter);

		public void RemoveWhere(Expression<Func<T, bool>> filter);

		public void UpdateOne(Expression<Func<T, bool>> filter, T obj);

		public void Add(T obj);

		public void AddMany(IEnumerable<T> objs);
	}
}
