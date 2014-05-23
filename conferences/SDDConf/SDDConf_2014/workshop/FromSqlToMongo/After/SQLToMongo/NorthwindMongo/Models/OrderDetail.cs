using System;
using System.Linq;
using MongoDB.Bson;

namespace NorthwindMongo.Models
{
	public class OrderDetail
	{
		public ObjectId ProductID { get; set; }

		public short Quantity { get; set; }

		public decimal UnitPrice { get; set; }
	}
}