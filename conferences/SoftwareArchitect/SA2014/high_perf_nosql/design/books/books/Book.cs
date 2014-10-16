using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace books
{

	public class Book
	{
		public ObjectId Id { get; set; }
		public string Name { get; set; }
		public string ISBN { get; set; }
		public DateTime Published { get; set; }
		[BsonIgnore]
		public bool IsPopular { get; set; }
		public List<Review> Reviews { get; set; }

		public string PopularText { get; set; }

		[BsonExtraElements]
		public BsonDocument AddtionalData { get; set; }

		public Book()
		{
			Reviews = new List<Review>();
		}
	}

	//public class Book
	//{
	//	public ObjectId Id { get; set; }
	//	//public string Name { get; set; }
	//	//public string ISBN { get; set; }
	//	//public DateTime Published { get; set; }
	//	//[BsonIgnore]
	//	//public bool IsPopular { get; set; }
	//	public List<Review> Reviews { get; set; }

	//	public string PopularText { get; set; }

	//	[BsonExtraElements]
	//	public BsonDocument AddtionalData { get; set; }

	//	public Book()
	//	{
	//		Reviews = new List<Review>();
	//	}
	//}

	public class Review
	{
		public string User { get; set; }
		public DateTime Created { get; set; }

		public Review()
		{
			this.Created = DateTime.Now;
		}
	}
	
	public class Book2
	{
		public ObjectId Id { get; set; }
		public string Name { get; set; }
		public string ISBN { get; set; }
		public DateTime Published { get; set; }
		public List<ObjectId> ReviewIds { get; set; }

		public Book2()
		{
			ReviewIds = new List<ObjectId>();
		}
	}

	public class Review2
	{
		public ObjectId Id { get; set; }
		public string User { get; set; }
		public DateTime Created { get; set; }

		public Review2()
		{
			this.Created = DateTime.Now;
		}
	}
}