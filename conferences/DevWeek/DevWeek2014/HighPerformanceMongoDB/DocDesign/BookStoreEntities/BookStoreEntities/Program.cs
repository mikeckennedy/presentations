using System;
using System.Linq;
using BookStoreEntities.Models;

namespace BookStoreEntities
{
	class Program
	{
		static void Main(string[] args)
		{
			ReloadBooks();
			//AddData();
			//FindAuthorsOfSecondBook();
		}

		private static void ReloadBooks()
		{
			MongoContext mongo = new MongoContext();
			foreach (var b in mongo.Books)
			{
				mongo.Save(b);
			}
		}

		private static void FindAuthorsOfSecondBook()
		{
			MongoContext mongo = new MongoContext();

			var book = mongo.Books.Single(b => b.Title == "Second book");

			// db.Author.find( {_id: {$in: [1, 2, 7]} )
			var authors =
				from a in mongo.Authors
				where book.AuthorIds.Contains(a.Id)
				orderby a.Name
				select a;

			Console.WriteLine(book.Title);
			foreach (var a in authors)
			{
				Console.WriteLine("\t"+a.Name);
			}
		}

		private static void AddData()
		{

			MongoContext mongo = new MongoContext();

			Author a = new Author() { Name = "Jeff" };
			Author bl = new Author() {Name = "Bill"};
			Author t = new Author() {Name = "Ted"};
			mongo.Save(a);
			mongo.Save(bl);
			mongo.Save(t);

			Book b = new Book();
			b.ISBN = "123";
			b.Title = "First book";
			b.AuthorIds.Add(a.Id);

			mongo.Save(b);
			
			b = new Book();
			b.ISBN = "234";
			b.Title = "Second book";
			b.AuthorIds.Add(bl.Id);
			b.AuthorIds.Add(t.Id);

			mongo.Save(b);
		}
	}
}
