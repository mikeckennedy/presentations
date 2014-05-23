using System;
using System.Linq;
using MongoDB.Kennedy;

namespace CarApp.Data
{
    internal class MongoContext : MongoDbDataContext
    {
        public MongoContext()
            : base("CarDealership")
        {
        }

        public IQueryable<Car> Cars
        {
            get { return base.GetCollection<Car>().AsQueryable(); }
        }
    }
}