using MongoDB.Bson;

namespace BookStore
{
    public class Rating
    {
        public ObjectId UserId { get; set; }
        public int Value { get; set; }
    }
}