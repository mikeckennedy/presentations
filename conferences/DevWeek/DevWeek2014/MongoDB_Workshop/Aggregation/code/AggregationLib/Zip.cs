using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace AggregationLib
{
    public class Zip
    {
        [BsonId]
        public string Code { get; set; }
        [BsonElement("state")]
        public string State { get; set; }
        [BsonElement("pop")]
        public int Population { get; set; }
        [BsonElement("city")]
        public string City { get; set; }
        [BsonElement("loc")]
        public double[] Location { get; set; }
    }
}
