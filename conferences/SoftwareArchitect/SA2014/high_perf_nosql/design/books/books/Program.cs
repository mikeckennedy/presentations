using System;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace books
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			//Book b = new Book();
			//b.ISBN = "03987498w3";
			//b.Name = "Harry Potter";
			//b.Published = DateTime.Now;
			//b.Reviews.Add(new Review() {User="Ted"});
			//b.Reviews.Add(new Review() {User="John"});
			//b.Reviews.Add(new Review() {User="Sarah"});

			//var mongo = new MongoContext();

			//mongo.Save(b);

			//b = new Book();
			//b.ISBN = "03987498w4";
			//b.Name = "Harry Potter II";
			//b.Published = DateTime.Now;
			//b.Reviews.Add(new Review() { User = "Jeff" });
			//b.Reviews.Add(new Review() { User = "Sarah" });

			//mongo.Save(b);

			//var mongo = new MongoContext();


			//Book2 b = new Book2();
			//b.ISBN = "03987498w3";
			//b.Name = "Harry Potter";
			//b.Published = DateTime.Now;
			
			//var r = new Review2() { User = "Ted" };
			//mongo.Save(r);
			//b.ReviewIds.Add(r.Id);
			//r = new Review2() { User = "John" };
			//mongo.Save(r);
			//b.ReviewIds.Add(r.Id);
			//r = new Review2() { User = "Sarah" };
			//mongo.Save(r);
			//b.ReviewIds.Add(r.Id);
			
			//mongo.Save(b);


			var mongo = new MongoContext();
			var b = mongo.Books2
				.Single(b2 => b2.Name == "Harry Potter");

			var reviews = mongo.Reviews
				.Where(r => b.ReviewIds.Contains(r.Id));

			Console.WriteLine(b.ToBsonDocument());
			Console.WriteLine(reviews.First().ToBsonDocument());


		}
	}
}