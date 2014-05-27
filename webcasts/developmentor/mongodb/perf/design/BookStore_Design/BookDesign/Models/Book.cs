using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDesign.Models;
using MongoDB.Bson;

namespace BookDesign
{
    class Book
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PageCount { get; set; }

        public List<Review> Reviews { get; set; }

        public Book()
        {
            Reviews = new List<Review>();   
        }
    }
}
