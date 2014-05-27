using System;
using System.Diagnostics;
using System.Linq;
using BookStore;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using MongoDB.Extensions;

namespace BookStoreTest
{
	internal class Program
	{
		private static void Main()
		{
			try
			{
				using (new ConsoleColorContext(ConsoleColor.Gray))
				{
					Run();
				}
			}
			catch (NotImplementedException e)
			{
				using (new ConsoleColorContext(ConsoleColor.Red))
				{
					Console.WriteLine("Looks like you still have some work to do:\n\n" + e.Message + "\n");
				}
			}
		}

		private static void Run()
		{
			ConsoleHelper.Message("Running (after code) ...");
			Console.WriteLine(); 
			
			const int slowMs = 5;
			ConsoleHelper.Message("Removing indexes...");
			RemoveAllIndexes();

			ConsoleHelper.Message("Resetting profiling...");
			OurMongoHelper.RemoveOldProfileData();
			OurMongoHelper.EnableProfiling(slowMs);

			ConsoleHelper.Message("Running standard queries (generates profiling data)");
			QueryData();

			ConsoleHelper.Message("Displaying top 10 worst queries (slower than 5 ms) ...");
			DisplayBadQueries(slowMs, 10);
			Console.WriteLine();

			ConsoleHelper.Prompt("Paused, enter to continue...");
			Console.WriteLine();

			ConsoleHelper.Message("Showing query times and plans with results...");
			ShowTimesAndQueryPlans();
			Console.WriteLine();

			ConsoleHelper.Message("Adding indexes (this is s.l.o.w.) ...");
			AddIndexes();

			ConsoleHelper.Message("Resetting profiling...");
			OurMongoHelper.RemoveOldProfileData();
			OurMongoHelper.EnableProfiling(slowMs);

			ConsoleHelper.Message("Querying data with indexes (generates profiling data)...");
			QueryData();

			ConsoleHelper.Message("Displaying top 10 worst queries (slower than 5 ms) ...");
			ConsoleHelper.Message("Is this empty? It probably should be:");
			DisplayBadQueries(slowMs, 10);
			Console.WriteLine();

			ConsoleHelper.Message("Showing query times and plans with results (should be faster) ...");
			ShowTimesAndQueryPlans();
			
			ConsoleHelper.Message("Done!");
			Console.ReadKey(true);
		}

		private static void ShowTimesAndQueryPlans()
		{
			BookStoreContext mongo = new BookStoreContext();
			var users = mongo.Users.AsQueryable();
			var publishers = mongo.Publishers.AsQueryable();
			var books = mongo.Books.AsQueryable();

			var query1 = users.Where(u => u.Age == 18);
			int eighteenYearOlds = -1;
			double dt = Perf.Timed(() => eighteenYearOlds = query1.Count());
			CursorType curstorType = query1.Explain().Deserialize<QueryPlan>().CursorType;

			Console.WriteLine("{0:N0} users are 18 years old, cursor={1}, duration={2:N1} ms.",
				eighteenYearOlds, curstorType, dt);


			var query2 = users.Where(u => u.UserId == 127472).Select(u => u.Location.City);
			string city = null;
			dt = Perf.Timed(() => city = query2.FirstOrDefault());
			curstorType = query2.Explain().Deserialize<QueryPlan>().CursorType;

			Console.WriteLine("User 127472 lives in {0}, cursor={1}, duration={2:N1} ms.",
				city, curstorType, dt);


			var query3 = users.Where(u => u.Age >= 18);
			int adults = -1;
			dt = Perf.Timed(() => adults = query3.Count());
			curstorType = query3.Explain().Deserialize<QueryPlan>().CursorType;

			Console.WriteLine("{0:N0} users who are 18 years old, cursor={1}, duration={2:N1} ms.",
				adults, curstorType, dt);


			var query4 = users.Where(u => u.Age >= 18 && u.Age <= 30);
			adults = -1;
			dt = Perf.Timed(() => adults = query4.Count());
			curstorType = query4.Explain().Deserialize<QueryPlan>().CursorType;

			Console.WriteLine("{0:N0} users who are between 18 and 30, cursor={1}, duration={2:N1} ms.",
				adults, curstorType, dt);


			var query5 = users.Where(u => u.Location.City == "moscow");
			int people = -1;
			dt = Perf.Timed(() => people = query5.Count());
			curstorType = query5.Explain().Deserialize<QueryPlan>().CursorType;

			Console.WriteLine("{0:N0} users who live in moscow, cursor={1}, duration={2:N1} ms.",
				people, curstorType, dt);


			var publisherId = publishers.Single(p => p.Name == "2nd Avenue Publishing, Inc.").Id;
			var query6 = books
				.Where(b => b.Publisher == publisherId);
			int bookCount6 = -1;
			dt = Perf.Timed(() => bookCount6 = query6.Count());
			curstorType = query6.Explain().Deserialize<QueryPlan>().CursorType;

			Console.WriteLine("books published by 2nd Avenue: {0:N0}, cursor={1}, duration={2:N1} ms.",
				bookCount6, curstorType, dt);


			var query7 = books
				.Where(b => b.Author == "John Grisham");
			var bookCount7 = -1;
			dt = Perf.Timed(() => bookCount7 = query7.Count());
			curstorType = query7.Explain().Deserialize<QueryPlan>().CursorType;

			Console.WriteLine("John Grisham wrote {0:N0} books, cursor={1}, duration={2:N1} ms.",
				bookCount7, curstorType, dt);

			var query8 = books
				.Where(b => b.Author == "John Grisham" && b.Published >= new DateTime(2003, 1, 1));

			var bookCount8 = -1;
			dt = Perf.Timed(() => bookCount8 = query8.Count());
			curstorType = query8.Explain().Deserialize<QueryPlan>().CursorType;

			Console.WriteLine("John Grisham wrote {0:N0} books after jan 1st 2003, cursor={1}, duration={2:N1} ms.",
				bookCount8, curstorType, dt);

			var query9 = books.Where(b => b.Ratings.Any(r => r.Value >= 0));
			long bookCount9 = -1;
			dt = Perf.Timed(() => bookCount9 = query9.Count());
			var queryPlan = query9.Explain().Deserialize<QueryPlan>();
			curstorType = queryPlan.CursorType;

			Console.WriteLine("{0:N0} books with ratings, cursor={1}, duration={2:N1} ms.",
				bookCount9, curstorType, dt);

			

			var query10 = books.Where(b => b.Ratings.Any(r => r.Value >= 5));
			var bookCount10 = -1;
			dt = Perf.Timed(() => bookCount10 = query10.Count());
			queryPlan = query10.Explain().Deserialize<QueryPlan>();
			curstorType = queryPlan.CursorType;

			Console.WriteLine("{0:N0} books with high rating, cursor={1}, duration={2:N1} ms.",
				bookCount10, curstorType, dt);



			var userId = new ObjectId("525867733a93bb2198146034");
			var query11 = books.Where(b => b.Ratings.Any(r => r.UserId == userId));
			var bookCount11 = -1;
			dt = Perf.Timed(() => bookCount11 = query11.Count());
			queryPlan = query11.Explain().Deserialize<QueryPlan>();
			curstorType = queryPlan.CursorType;

			Console.WriteLine("User 529...93a rated {0:N0} books, cursor={1}, duration={2:N1} ms.",
				bookCount11, curstorType, dt);


			var query12 = books.Where(b => b.Ratings.Any(r => r.UserId == userId && r.Value >= 5));
			var bookCount12 = -1;
			dt = Perf.Timed(() => bookCount12 = query12.Count());
			curstorType = query12.Explain().Deserialize<QueryPlan>().CursorType;

			Console.WriteLine("User 529...93a highly rated {0:N0} book, cursor={1}, duration={2:N1} ms.",
				bookCount12, curstorType, dt);
		}
		
		private static void RemoveAllIndexes()
		{
			var mongo = new BookStoreContext();
			mongo.Publishers.DropAllIndexes();
			mongo.Users.DropAllIndexes();
			mongo.Books.DropAllIndexes();
		}

		private static void AddIndexes()
		{
			var mongo = new BookStoreContext();
			mongo.Books.CreateIndex(new IndexKeysBuilder<Book>().Ascending(b => b.Author));
			mongo.Books.CreateIndex("Ratings.Value");
			mongo.Books.CreateIndex("Ratings.UserId", "Ratings.Value");
			mongo.Books.CreateIndex("Publisher");
			mongo.Books.CreateIndex("Published");
			mongo.Users.CreateIndex("Age");
			mongo.Users.CreateIndex(new IndexKeysBuilder<User>().Ascending(u => u.UserId));
			mongo.Users.CreateIndex("Location.City");
			mongo.Publishers.CreateIndex(new IndexKeysBuilder<Publisher>().Ascending(p => p.Name));
		}	

		private static void QueryData()
		{
			BookStoreContext mongo = new BookStoreContext();
			var users = mongo.Users.AsQueryable();
			var publishers = mongo.Publishers.AsQueryable();
			var books = mongo.Books.AsQueryable();
			int aa= users.Count(u => u.Age == 18);
			var bb= users.Single(u => u.UserId == 3);
			var cc = users.Count(u => u.Age >= 18);
			var dd = users.Count(u => u.Age >= 18 && u.Age <= 30);
			var ee= users.Count(u => u.Location.City == "moscow");
			var publisherId = publishers.Single(p => p.Name == "2nd Avenue Publishing, Inc.").Id;
			var ff = books.Where(b => b.Publisher == publisherId).Select(b => b.Title).LastOrDefault();
			var gg = books.Count(b => b.Published >= new DateTime(2003, 1, 1));
			var hh = books.Where(b => b.Author == "John Grisham").Select(b => b.Title).ToArray();
			var ii = books.Where(b => b.Author == "John Grisham" && b.Published >= new DateTime(2003, 1, 1)).Select(b => b.Title).ToArray();
			var xx = books.Where(b => b.Ratings.Any(r => r.Value >= 0)).Count();
			var yy = books.Where(b => b.Ratings.Any(r => r.Value >= 5)).Count();
			var jj = books.Count(b => b.Ratings.Any(r => r.Value >= 0));
			var kk = books.Count(b => b.Ratings.Any(r => r.Value >= 5));
			var userId = new ObjectId("529f92eda6e10b55bc81293a");
			var ll = books.Where(b => b.Ratings.Any(r => r.UserId == userId)).Select(b => b.Title).LastOrDefault();
			var mm = books.Where(b => b.Ratings.Any(r => r.UserId == userId && r.Value >= 5)).Select(b => b.Title).LastOrDefault();
		}

		private static void DisplayBadQueries(int slowMs, int numberToShow)
		{
			TimeSpan dt = TimeSpan.FromMilliseconds(slowMs);

			BookStoreContext mongo = new BookStoreContext();
			var profileInfos = mongo.Database.GetCollection<SystemProfileInfo>("system.profile").AsQueryable();
			var badQueries =
				(from p in profileInfos
				 where p.Duration >= dt && p.Op == "query" 
				 orderby p.Duration descending
				 select new { p.Namespace, p.Duration, p.Command, p.Query })
				.AsEnumerable()
				.Where(p => !p.Query.ToString().Contains("\"$explain\""))
				.Distinct()
				.Take(numberToShow);

			foreach (var q in badQueries)
			{
				Console.WriteLine("{1:N0} ms, coll={0}, query={2}", q.Namespace, q.Duration.TotalMilliseconds, q.Query);
			}
		}
	}
}