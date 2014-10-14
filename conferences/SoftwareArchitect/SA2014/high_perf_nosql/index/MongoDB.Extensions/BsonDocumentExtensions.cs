using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace MongoDB.Extensions
{
	public static class BsonDocumentExtensions
	{
		public static T Deserialize<T>(this BsonDocument doc)
		{
			return BsonSerializer.Deserialize<T>(doc);
		}
	}
}