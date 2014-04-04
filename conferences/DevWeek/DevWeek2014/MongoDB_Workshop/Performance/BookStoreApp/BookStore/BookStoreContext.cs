using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace BookStore
{
    public enum ClusterType
    {
        ParallelSort,
        SerialServer
    }

    public class BookStoreContext
    {
        private MongoDatabase _db;

        public BookStoreContext()
        {
            _db = new MongoClient().GetServer().GetDatabase("BookStore");
        }

        public MongoDatabase Database { get { return _db; } }

        public MongoCollection<Book> Books
        {
            get
            {
                return _db.GetCollection<Book>();
            }
        }
        public MongoCollection<User> Users
        {
            get
            {
                return _db.GetCollection<User>();
            }
        }
        public MongoCollection<Publisher> Publishers
        {
            get
            {
                return _db.GetCollection<Publisher>();
            }
        }
    }
}
