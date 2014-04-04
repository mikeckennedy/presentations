using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealer.Models;
using MongoDB;
using MongoDB.Driver.Builders;

namespace CarDealer
{
	class Program
	{
		static void Main(string[] args)
		{
			ResetData();
			AddData();
			//AddDealers();
			QueryData();
			ModiyData();
			InplaceUpdate();
			WhoOwnsYou();
		}

		private static void WhoOwnsYou()
		{
			MongoContext mongo = new MongoContext();
			var customer1 = mongo.Customers.First();
			WhoOwnsThisCar(customer1.Cars[0]);
		}

		private static void WhoOwnsThisCar(Car car)
		{
			Console.WriteLine("Who owns {0}? Well {1} does!",
				car.Type, car.Customer.ContactInfo.Name);
		}

		private static void ResetData()
		{
			MongoContext mongo = new MongoContext();
			foreach (var c in mongo.Customers)
			{
				mongo.Save(c);
			}
		}

		private static void AddDealers()
		{
			MongoContext mongo = new MongoContext();

			var d = new Dealer();
			d.Name = "Cheapo won't make it home cars II!";

			Console.WriteLine("Before time is: " + d.Created);

			mongo.Save(d);

			d = mongo.Dealers.Single(deal => deal.Name == d.Name);
			Console.WriteLine("After time is: " + d.Created);
		}

		private static void InplaceUpdate()
		{
			MongoContext mongo = new MongoContext();
			var q = Query<Customer>.Where(c => c.ContactInfo.City != "Portland");
			var u = Update<Customer>.Set(c => c.ContactInfo.Name, "Tesla Owner");
			
			mongo.CustomersCollection.Update(q, u);
		}

		private static void ModiyData()
		{
			MongoContext mongo = new MongoContext();

			Customer first = mongo.Customers.First();
			first.ContactInfo.Name = "Michael Kennedy";

			mongo.Save(first);
		}

		private static void QueryData()
		{
			MongoContext mongo = new MongoContext();

			var electricUsers =
				from cu in mongo.Customers
				where cu.Cars.Any(c => c.Engine.Type == "V6")
				orderby cu.ContactInfo.City
				select cu;

			Console.WriteLine(electricUsers.ToMongoQueryText());

			foreach (var customer in electricUsers)
			{
				Console.WriteLine(customer.ContactInfo.City);
				foreach (var car in customer.Cars)
				{
					Console.WriteLine("\t{0} - {1}, color: {2}", car.Type, car.Engine.Type, car.Color);
				}
			}		
		}

		private static void AddData()
		{
			MongoContext mongo = new MongoContext();

			if (mongo.Customers.Any())
			{
				return;
			}

			var c1 = new Customer();
			c1.ContactInfo.City = "Portland";
			c1.ContactInfo.Country = "USA";
			c1.Cars.Add(
				new Car()
				{
					//Color = Color.Yellow,
					Type = "Lotus",
					Year = 2014,
					Engine = new Engine
					{
						Cylinders = 6,
						Type = "V6"
					}
				});
			c1.Cars.Add(
				new Car()
				{
					//Color = Color.Black,
					Type = "Minivan",
					Year = 2001,
					Engine = new Engine
					{
						Cylinders = 8,
						Type = "V8"
					}
				});


			var c2 = new Customer();
			c2.ContactInfo.City = "Portland";
			c2.ContactInfo.Country = "USA";
			c2.Cars.Add(
				new Car()
				{
					//Color = Color.Yellow,
					Type = "Lotus",
					Year = 2014,
					Engine = new Engine
					{
						Cylinders = 6,
						Type = "V6"
					}
				});
			c2.Cars.Add(
				new Car()
				{
					//Color = Color.Black,
					Type = "Minivan",
					Year = 2001,
					Engine = new Engine
					{
						Cylinders = 8,
						Type = "V8"
					}
				});

			mongo.Save(c1);
			
			mongo.Save(c2);
		}
	}
}
