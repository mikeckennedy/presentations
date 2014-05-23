using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace NorthwindMongo.Models
{
	public class Order
	{
		public ObjectId Id { get; set; }
		public decimal? Freight { get; set; }
		public DateTime? OrderDate { get; set; }
		public DateTime? RequiredDate { get; set; }
		public string ShipAddress { get; set; }
		public string ShipCity { get; set; }
		public string ShipCountry { get; set; }
		public string ShipName { get; set; }
		public string ShipPostalCode { get; set; }
		public string ShipRegion { get; set; }
		public int? ShipVia { get; set; }
		public DateTime? ShippedDate { get; set; }
		public List<OrderDetail> OrderDetails { get; set; }

		public Order()
		{
			OrderDetails = new List<OrderDetail>();
		}
	}
}