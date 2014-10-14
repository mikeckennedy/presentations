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
			base("PerfDb_BookStore_SA2014")
		{
		}

		public IQueryable<Book> Books
		{
			get { return base.GetCollection<Book>(); }
		}

		public MongoCollection<Book> BooksColl
		{
			get { return base.GetMongoCollection<Book>(); }
		}
	}
}
