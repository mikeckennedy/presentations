using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace CarApp.Data
{
    class ServiceRecord
    {
        public ObjectId Id { get; set; }
        public DateTime Created { get; set; }
        public string Desc { get; set; }
        public double Price { get; set; }

        public ServiceRecord()
        {
            Created = DateTime.Now;
            Id = ObjectId.GenerateNewId();
        }
    }
}
