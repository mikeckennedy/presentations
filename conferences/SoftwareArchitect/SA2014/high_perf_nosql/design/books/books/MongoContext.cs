using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace books
{
	public class MongoContext : MongoDB.Kennedy.MongoDbDataContext
	{
		public MongoContext() :
			base("SA_Perf_Design")
		{
		}

		public IQueryable<Book> Books { get { return base.GetCollection<Book>(); } }
	}

}
