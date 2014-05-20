using System;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using SddConfNoSQLBlog.Models;

namespace SddConfNoSQLBlog
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to the SDD NoSQL Blog " +
			                  "App by @mkennedy");

			AddData();
			FindSomeData();
			UpdateData();
			var mongo = new MongoContext();
			ShowPostTitle(mongo.Posts.First(p => p.Comments.Any()).Comments.First());

			ViewPost();
		}

		private static void ViewPost()
		{
			var mongo = new MongoContext();
			var id = new ObjectId("537b5e043a93bb271065d66e");
			//var post = mongo.Posts.OrderBy(p => p.Created).First();
			//post.ViewCount++;
			//mongo.Save(post);

			var q = Query<Post>.Where(p => p.Id == id);
			var u = Update<Post>.Inc(p => p.ViewCount, 1);

			mongo.PostsCollection.Update(q, u);
		}

		private static void UpdateData()
		{
			var mongo = new MongoContext();

			var id = new ObjectId("537b5e043a93bb271065d66e");
			var post = mongo.Posts.Single(p => p.Id == id);

			if (post.Comments.Count > 0)
			{
				Console.WriteLine("Would update {0} which was created at {1}",
					post.Title, post.Created);
				return;
			}

			post.Comments.Add(new Comment() {Text = "Yay, for comments"});
			post.Comments.Add(new Comment() {Text = "More comments"});

			mongo.Save(post);
			Console.WriteLine("Added comments");
		}

		private static void FindSomeData()
		{
			var mongo = new MongoContext();

			const string targetTag = "NoSQL";
			var posts =
				from p in mongo.Posts
				where p.Tags.Contains(targetTag)
				orderby p.Created descending 
				select p;

			foreach (var p in posts)
			{
				Console.WriteLine(p.Title);
				foreach (var t in p.Tags)
				{
					Console.Write("\t" + t);
				}
				Console.WriteLine();
			}
		}

		private static void AddData()
		{
			var mongo = new MongoContext();
			Console.WriteLine("Adding data");
			if (mongo.Posts.Any())
			{
				Console.WriteLine("Data already inserted, exiting..");
				return;
			}

			Post p = new Post();
			p.Title = "First NoSQL Post!";
			p.Content = "This is content...";
			p.Tags.Add("MongoDB");
			p.Tags.Add("NoSQL");
			mongo.Save(p);

			p = new Post();
			p.Title = "Second NoSQL Post!";
			p.Content = "This is content...";
			p.Tags.Add("NoSQL");
			mongo.Save(p);

			p = new Post();
			p.Title = "Hello conf!";
			p.Content = "This is content...";
			p.Tags.Add("SDD");
			p.Tags.Add("MongoDB");
			mongo.Save(p);

			Console.WriteLine("Data added.");
		}

		private static void ShowPostTitle(Comment c)
		{
			Post p = c.Post;
			Console.WriteLine("Post of comment is " + p.Title);
		}
	}

}
