using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookStore
{
	class Review
	{
		public int UserId { get; set; }
		public string Text { get; set; }
		public DateTime Created { get; set; }

		public Review()
		{
			Created = DateTime.UtcNow;
		}
	}

	class Review2
	{
		public ObjectId Id { get; set; }
		public int UserId { get; set; }
		public string Text { get; set; }
		public DateTime Created { get; set; }

		[BsonExtraElements]
		public BsonDocument AdditionalData { get; set; }

		public Review2()
		{
			Created = DateTime.UtcNow;
		}
	}
}
