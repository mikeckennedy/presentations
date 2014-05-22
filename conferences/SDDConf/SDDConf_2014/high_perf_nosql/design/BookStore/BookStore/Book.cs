using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace BookStore
{
	class Book
	{
		public ObjectId Id { get; set; }
		public string Title { get; set; }
		public string ISBN { get; set; }

		public List<Review> Reviews { get; set; }
		//public List<ObjectId> ReviewIds { get; set; }

		public Book()
		{
			Reviews = new List<Review>();
		}
	}

	class Book2
	{
		public ObjectId Id { get; set; }
		public string Title { get; set; }
		public string ISBN { get; set; }

		public List<ObjectId> ReviewIds { get; set; }
		//public List<ObjectId> ReviewIds { get; set; }

		public Book2()
		{
			ReviewIds = new List<ObjectId>();
		}
	}
}
