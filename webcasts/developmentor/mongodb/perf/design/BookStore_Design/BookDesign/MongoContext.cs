using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDesign
{
    class MongoContext : MongoDB.Kennedy.MongoDbDataContext
    {
        public MongoContext() : 
            base("Dm_WebCast_BookStore")
        {
        }

        public IQueryable<Book> Books
        {
            get { return base.GetCollection<Book>(); }
        }
    }
}
