using MongoDB.Driver;

namespace BookStore
{
    static class MongoExtensions
    {
        public static MongoCollection<T> GetCollection<T>(this MongoDatabase db)
        {
            return db.GetCollection<T>(typeof (T).Name);
        }
    }
}