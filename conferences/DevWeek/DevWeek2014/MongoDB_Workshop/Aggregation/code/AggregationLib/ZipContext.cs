using MongoDB.Driver;

namespace AggregationLib
{
    public class ZipContext
    {
        private MongoDatabase _db;

        public ZipContext()
        {
            var mongoClient = new MongoClient();
            this._db = mongoClient.GetServer().GetDatabase("zipdb");
        }

        public MongoCollection<Zip> Zips
        {
            get
            {
                return _db.GetCollection<Zip>("Zip");
            }
        }
    }
}