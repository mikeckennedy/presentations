using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Kennedy;

namespace BookStoreEntities.Models
{
	class Book
	{
		public ObjectId Id { get; set; }
		public string ISBN { get; set; }
		public string Title { get; set; }
		public string DatedText { get; set; }
		public List<ObjectId> AuthorIds { get; set; }
		
		public Book()
		{
			//Created = DateTime.UtcNow;
			AuthorIds = new List<ObjectId>();
		}
	}

	internal class Author
	{
		public ObjectId Id { get; set; }
		public string Name { get; set; }
		public string ImageUrl { get; set; }
	}

	class MongoContext : MongoDbDataContext
	{
		public MongoContext() : base("DevWeekBooks")
		{
		}

		public IQueryable<Book> Books
		{
			get { return base.GetCollection<Book>(); }
		}
		public IQueryable<Author> Authors
		{
			get { return base.GetCollection<Author>(); }
		}
	}
}
