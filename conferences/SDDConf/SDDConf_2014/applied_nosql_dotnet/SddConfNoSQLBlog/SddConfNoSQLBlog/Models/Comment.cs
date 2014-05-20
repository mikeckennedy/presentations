using System;
using System.Linq;
using System.Runtime;
using Microsoft.Win32;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SddConfNoSQLBlog.Models
{
	public class Comment
	{
		public String Text { get; set; }
		public ObjectId UserId { get; set; }
		
		[BsonIgnore]
		public Post Post { get; set; }
	}
}
