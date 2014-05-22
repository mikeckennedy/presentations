using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace BookStore
{
	class MongoContext : MongoDB.Kennedy.MongoDbDataContext
	{
		public MongoContext() :
			base("PerfDb")
		{
		}

		public IQueryable<Book> Books
		{
			get { return base.GetCollection<Book>(); }
		}

		public IQueryable<Book2> Books2
		{
			get { return base.GetCollection<Book2>(); }
		}
		public IQueryable<Review2> Reviews
		{
			get { return base.GetCollection<Review2>(); }
		}

		public MongoCollection<Book> BooksColl
		{
			get { return base.GetMongoCollection<Book>(); }
		}
	}
}
