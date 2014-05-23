using System;
using System.Linq;
using MongoDB.Bson;

namespace NorthwindMongo.Models
{
	public class Category
	{
		public ObjectId Id { get; set; }
		public DateTime Created { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public byte[] Picture { get; set; }

		public Category()
		{
			this.Created = DateTime.UtcNow;
		}
	}
}