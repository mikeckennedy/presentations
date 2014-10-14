using MongoDB.Bson;

namespace BookStore
{
    public class User
    {
        public ObjectId Id { get; set; }
        public int UserId { get; set; }
        public int Age { get; set; }
        public Location Location { get; set; }
        
    }
}