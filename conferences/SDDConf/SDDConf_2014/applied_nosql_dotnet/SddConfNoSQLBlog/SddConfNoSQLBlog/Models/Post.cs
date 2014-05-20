using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SddConfNoSQLBlog.Models
{
	public class Post : ISupportInitialize
	{
		// required, top level
		public ObjectId Id { get; set; }

		// Data
		public string Title { get; set; }
		public int ViewCount { get; set; }
		public string Content { get; set; }
		public string Url { get; set; }
		public List<string> Tags { get; set; }
		[BsonDateTimeOptions(Kind = DateTimeKind.Local)]
		public DateTime Created { get; set; }
		public List<Comment> Comments { get; set; }

		public Post()
		{
			Created = DateTime.Now;
			Comments = new List<Comment>();
			Tags = new List<string>();
		}

		public void BeginInit()
		{
		}

		public void EndInit()
		{
			foreach (var c in this.Comments)
			{
				c.Post = this;
			}
		}
	}
}
