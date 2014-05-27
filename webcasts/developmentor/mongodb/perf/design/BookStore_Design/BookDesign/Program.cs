using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using BookDesign.Models;

namespace BookDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            AddData();
            FindBooks();
        }

        private static void FindBooks()
        {
            MongoContext mongo = new MongoContext();

            var bigBooks =
                from b in mongo.Books
                where b.PageCount >= 200
                select b;

            foreach (var book in bigBooks)
            {

                Console.WriteLine(book.Title);
            }
        }

        private static void AddData()
        {
            MongoContext mongo = new MongoContext();

            if (mongo.Books.Any())
            {
                Console.WriteLine("Books already entered.");
                return;
            }

            Book book = new Book();
            book.Title = "First mongodb book";
            book.ISBN = "349823749827";
            book.PageCount = 200;
            mongo.Save(book);
            
            book = new Book();
            book.Title = "Second mongodb book";
            book.ISBN = "0348503984093848";
            book.PageCount = 100;
            mongo.Save(book);
            
            book = new Book();
            book.Title = "C# book";
            book.ISBN = "9384938";
            book.PageCount = 300;
            book.Reviews.Add(new Review() {Comment = "Loved it!"});
            mongo.Save(book);
        }
    }
}
