using System;
using System.Linq;
using MongoDB.Driver;
using SddConfNoSQLBlog.Models;

namespace SddConfNoSQLBlog
{
	public class MongoContext : MongoDB.Kennedy.MongoDbDataContext
	{
		public MongoContext() : base("sddconf")
		{
		}

		public MongoCollection<Post> PostsCollection
		{
			get { return base.GetMongoCollection<Post>(); }
		}

		public IQueryable<Post> Posts
		{
			get { return base.GetCollection<Post>(); }
		}
	}
}
