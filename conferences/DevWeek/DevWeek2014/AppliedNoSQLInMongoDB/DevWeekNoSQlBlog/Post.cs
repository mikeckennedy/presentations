using System.CodeDom;
using System.ComponentModel;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace DevWeekNoSQlBlog
{
   // [BsonIgnoreExtraElements]
    public class Post : ISupportInitialize
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }
       
        public List<int> Votes { get; set; }
        public int ViewCount { get; set; }
        public List<string> Categories { get; set; }
        public List<Comment> Comments{ get; set; }

        public Post()
        {
           // Votes = new List<int>();
            Comments = new List<Comment>();
            Created = DateTime.Now;
        }

        public void BeginInit()
        {
            
        }

        public void EndInit()
        {
            foreach (var comment in this.Comments)
            {
                comment.Post = this;
            }
        }
    }

    class MongoContext : MongoDB.Kennedy.MongoDbDataContext
    {
        public MongoContext() : base("devweek2014_blog")
        {
        }

        public IQueryable<Post> Posts
        {
            get { return base.GetCollection<Post>(); }
        }


        public MongoCollection<Post> PostsCollection
        {
            get { return base.GetMongoCollection<Post>(); }
        }

    }
}
