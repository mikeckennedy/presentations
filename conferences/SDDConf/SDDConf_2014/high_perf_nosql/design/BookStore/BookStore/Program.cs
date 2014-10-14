using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver.Builders;

namespace BookStore
{
	class Program
	{


		static void Main(string[] args)
		{
			var m = new MongoContext();

			if (!m.Books.Any(b => b.ISBN == "039850983498539485"))
			{
				var b1 = new Book()
				{
					ISBN = "039850983498539485",
					Title = "The only book to read!",
					Reviews = new List<Review>()
					{
						//new Review() {Text = "A review"},
						//new Review() {Text = "Another review"},
					}
				};

				m.Save(b1);

				var b2 = new Book()
				{
					ISBN = "089w8er9458938w908b",
					Title = "The other book to read! II",
					Reviews = new List<Review>()
					{
						new Review() {Text = "First review"},
						new Review() {Text = "Second review"},
					}
				};

				m.Save(b2);
			}

			var books =
				from b in m.Books
				where b.Title == "The only book to read!" && b.Reviews.Any()
				orderby b.Title descending
				select b;

			foreach (var book in books)
			{
				Console.WriteLine(book.Title);
			}

			var q = Query<Book>
				.Where(b => b.Title == "The only book to read!");

			var u = Update<Book>.Push(b => b.Reviews, new Review() { Text = "Pushing reviews is for the hipsters!" });

			m.BooksColl.Update(q, u);
		}
	}
}
