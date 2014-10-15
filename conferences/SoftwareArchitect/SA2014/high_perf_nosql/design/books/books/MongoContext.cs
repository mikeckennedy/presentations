using System.Linq;
using MongoDB.Kennedy;

namespace books
{
	public class MongoContext : MongoDbDataContext
	{
		public MongoContext() :
			base("SA_Perf_Design")
		{
		}

		public IQueryable<Book> Books
		{
			get { return base.GetCollection<Book>(); }
		}
	}
}