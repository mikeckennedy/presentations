using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace BookStore
{
    public class Book
    {
        public ObjectId Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Published { get; set; }
        public ObjectId? Publisher { get; set; }
        public List<ImageUrl> ImageUrls { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}