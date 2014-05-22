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

			foreach ( var book in m.Books)
			{
				var b2 = new Book2();
				b2.ISBN = book.ISBN;
				b2.Id = book.Id;
				b2.Title = book.Title;

				foreach (var review in book.Reviews)
				{
					Review2 r2 = new Review2();
					r2.Created = review.Created;
					r2.Text = review.Text;
					m.Save(r2);

					b2.ReviewIds.Add(r2.Id);
				}
				m.Save(b2);
			}
		}

		//static void Main(string[] args)
		//{
		//	var m = new MongoContext();

		//	//var b = new Book()
		//	//{
		//	//	ISBN = "089w8er9458938w908",
		//	//	Title = "The other book to read!",
		//	//	Reviews = new List<Review>()
		//	//	{
		//	//		new Review() {Text = "First review"},
		//	//		new Review() {Text = "Second review"},
		//	//	}
		//	//};

		//	//m.Save(b);

		//	var books =
		//		from b in m.Books
		//		where b.Title == "The only book to read!" && b.Reviews.Any()
		//		orderby b.Title descending
		//		select b;

		//	foreach (var book in books)
		//	{
		//		Console.WriteLine(book.Title);
		//	}

		//	var q = Query<Book>
		//		.Where(b => b.Title == "The only book to read!");

		//	var u = Update<Book>.Push(b => b.Reviews, new Review() {Text = "Pushing reviews is for the hipsters!"});

		//	m.BooksColl.Update(q, u);
		//}
	}
}
