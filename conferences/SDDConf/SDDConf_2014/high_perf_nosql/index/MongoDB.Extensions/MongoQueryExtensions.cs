using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

// ReSharper disable once CheckNamespace
namespace MongoDB
{
	public static class MongoQueryExtensions
	{
		public static IMongoQuery ToMongoQuery<T>(this IEnumerable<T> query)
		{
			MongoQueryable<T> mongoQuery = query as MongoQueryable<T>;
			if (mongoQuery != null) 
				return mongoQuery.GetMongoQuery();

			MongoCursor<T> mongoCursor = query as MongoCursor<T>;
			if (mongoCursor != null)
				return mongoCursor.Query;

			return null;
		}

		public static string ToMongoQueryText<T>(this IEnumerable<T> query)
		{
			var mongoQuery = query.ToMongoQuery();
			if (mongoQuery == null)
				return null;

			return mongoQuery.ToString();
		}
	}
}