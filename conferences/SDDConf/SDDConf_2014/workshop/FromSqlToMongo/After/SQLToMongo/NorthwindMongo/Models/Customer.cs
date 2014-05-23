using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindMongo.Models
{
	public class Customer
	{
		public MongoDB.Bson.ObjectId Id { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string CompanyName { get; set; }
		public string ContactName { get; set; }
		public string ContactTitle { get; set; }
		public string Country { get; set; }
		public string Fax { get; set; }
		public string Phone { get; set; }
		public string PostalCode { get; set; }
		public string Region { get; set; }
		public string SqlId { get; set; }
		public List<Order> Orders { get; set; }

		public Customer()
		{
			this.Orders = new List<Order>();
		}
	}
}