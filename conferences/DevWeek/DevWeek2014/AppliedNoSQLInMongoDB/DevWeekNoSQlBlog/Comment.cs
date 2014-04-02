using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace DevWeekNoSQlBlog
{
    public class Comment
    {
        public string Message { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }

        [BsonIgnore]
        public Post Post { get; set; }

        public Comment()
        {
            Created = DateTime.Now;
        }
    }
}
