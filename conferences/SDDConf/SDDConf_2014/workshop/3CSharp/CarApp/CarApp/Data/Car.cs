using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarApp.Data
{
    // Remove when saving if extras...
    //[BsonIgnoreExtraElements]
    class Car
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
       // public string Maker { get; set; }
        public Engine Engine { get; set; }
        [BsonRepresentation(BsonType.String)]
        public OurColor Color { get; set; }
        public DateTime Created { get; set; }
        public List<ServiceRecord> ServiceRecords { get; set; }

        // Round trip extras here...
        [BsonExtraElements]
        public BsonDocument AdditionalData { get; set; }

        public Car()
        {
            Created = DateTime.Now;
            ServiceRecords = new List<ServiceRecord>();
        }
    }

    public enum OurColor
    {
        None = 0,
        Blue = 2,
        Green = 1,
        Red = 3
    }
}
