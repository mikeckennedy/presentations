using System;
using System.Linq;
using MongoDB.Bson;

namespace NorthwindMongo.Models
{
	public class Product
	{
		public ObjectId Id { get; set; }
		public DateTime Created { get; set; }
		public ObjectId? CategoryID { get; set; }
		public bool Discontinued { get; set; }
		public string ProductName { get; set; }
		public string QuantityPerUnit { get; set; }
		public short? ReorderLevel { get; set; }
		public ObjectId? SupplierID { get; set; }
		public decimal? UnitPrice { get; set; }
		public short? UnitsInStock { get; set; }
		public short? UnitsOnOrder { get; set; }

		public Product()
		{
			this.Created = DateTime.UtcNow;
		}
	}
}