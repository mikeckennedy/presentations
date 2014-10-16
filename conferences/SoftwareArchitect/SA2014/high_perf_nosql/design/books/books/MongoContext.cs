using System.Linq;
using MongoDB.Kennedy;

namespace books
{
	public class MongoContext : MongoDbDataContext
	{
		public MongoContext() : base("SA_Perf_Design")
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
	}
}