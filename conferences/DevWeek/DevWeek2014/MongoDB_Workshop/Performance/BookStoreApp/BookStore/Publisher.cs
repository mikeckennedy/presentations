using MongoDB.Bson;

namespace BookStore
{
    public class Publisher
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}