using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Kennedy;

namespace CarDealer.Models
{
	public class MongoContext : MongoDbDataContext
	{
		public MongoContext()
			: base("MongoDealership")
		{
		}

		public IQueryable<Customer> Customers
		{
			get { return GetCollection<Customer>(); }
		}

		public IQueryable<Dealer> Dealers
		{
			get { return GetCollection<Dealer>(); }
		}


		public MongoCollection<Customer> CustomersCollection
		{
			get { return GetMongoCollection<Customer>(); }
		}

		//		public void Test() {
		//			BsonClassMap.RegisterClassMap<MyClass>(cm => {
		//	cm.MapProperty(c => c.SSN).ElementName("_id");
		//});
		//	}

		//});

	}
}
