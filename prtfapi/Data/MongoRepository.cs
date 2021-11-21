using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using prtfapi.Portfolio;

namespace prtfapi.Data
{
	public class MongoRepository<T> : IRepository<T>
	{
		IMongoCollection<T> collection;

		public MongoRepository(IMongoDatabase db)
		{
			MongoCollectionNameAttribute attr = (MongoCollectionNameAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(MongoCollectionNameAttribute));
			collection = db.GetCollection<T>(attr.collectionName);
		}

		public IQueryable<T> All()
		{
			return collection.AsQueryable();
		}

		public T WhereOne(Expression<Func<T, bool>> filter)
		{
			return All().Where(filter).FirstOrDefault();
		}

		public IEnumerable<T> Where(Expression<Func<T, bool>> filter)
		{
			return All().Where(filter);
		}

		public void RemoveWhere(Expression<Func<T, bool>> filter)
		{
			collection.DeleteMany(filter);
		}

		public void RemoveOneWhere(Expression<Func<T, bool>> filter)
		{
			collection.DeleteOne(filter);
		}

		public void UpdateOne(Expression<Func<T, bool>> filter, T obj)
		{
			collection.ReplaceOne(filter, obj);
		}

		public void Add(T obj)
		{
			collection.InsertOne(obj);
		}

		public void AddMany(IEnumerable<T> objs)
		{
			collection.InsertMany(objs);
		}
	}
}
