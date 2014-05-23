using System.Linq;
using MongoDB.Driver;
using MongoDB.Kennedy;
using NorthwindMongo.Models;

namespace NorthwindMongo
{
    public class NorthwindContext : MongoDbDataContext
    {
        public NorthwindContext() : base("northwind")
        {
        }

	    public IQueryable<Product> Products
	    {
		    get { return this.GetCollection<Product>(); }
	    }

		public IQueryable<Category> Categories
	    {
			get { return this.GetCollection<Category>(); }
	    }

		public IQueryable<Supplier> Suppliers
	    {
			get { return this.GetCollection<Supplier>(); }
	    }

		public IQueryable<Customer> Customers
	    {
			get { return this.GetCollection<Customer>(); }
	    }
    }
}
