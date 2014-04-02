using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Builders;

namespace DevWeekNoSQlBlog
{
	class Program
	{
		static void Main(string[] args)
		{
		    AddData();
		    for (int i = 0; i < 10; i++)
		    {
                QueryData();
                AtomicModifyData();
            }
		    OrmModifyData();
		}

        private static void AtomicModifyData()
        {
            MongoContext mongo = new MongoContext();

            var post = mongo.Posts.Single(p => p.Content == "First post in Mongo");
            Console.WriteLine("Before view count: " + post.ViewCount);

            Stopwatch sw = Stopwatch.StartNew();

            var q = Query<Post>.Where(p => p.Content == "First post in Mongo");
            var u = Update<Post>.Inc(p => p.ViewCount, 1);

            mongo.PostsCollection.Update(q, u);
            sw.Stop();
            post = mongo.Posts.Single(p => p.Content == "First post in Mongo");
            Console.WriteLine("After view count: " + post.ViewCount + " done in " +
                              sw.ElapsedMilliseconds.ToString("N0"));
        }

        private static void OrmModifyData()
        {
            MongoContext mongo = new MongoContext();

            var post = mongo.Posts.First();
            post.ViewCount++;
            post.Votes.Add(12);
            mongo.Save(post);

        }

        private static void QueryData()
        {
            Stopwatch sw = Stopwatch.StartNew();
            MongoContext mongo = new MongoContext();

            var query =
                from p in mongo.Posts
                where p.ViewCount >= 5 && p.Content != null
                orderby p.ViewCount  
                select p;

            var data = query.ToArray();
            sw.Stop();

            foreach (var post in data)
            {
                Console.WriteLine("{0} has {1} views.",
                    post.Title, post.ViewCount);
            }

            Console.WriteLine("Finished in {0:N0} ms.", sw.ElapsedMilliseconds);
        }

        private static void AddData()
        {
            MongoContext mongo = new MongoContext();

            if (mongo.Posts.Any())
                return;

            var post = new Post();
            post.Content = "First post in Mongo";
            post.Title = "First";

            mongo.Save(post);

            post = new Post();
            post.Content = "Second post in Mongo";
            post.Title = "Second";
            post.ViewCount = 10;
            mongo.Save(post);


            post = new Post();
            post.Content = "Third post in Mongo";
            post.Title = "Third";
            post.ViewCount = 5;
            post.Votes.AddRange(new[]{1, 5, 5, 2, 11});
            mongo.Save(post);
        }
	}
}
