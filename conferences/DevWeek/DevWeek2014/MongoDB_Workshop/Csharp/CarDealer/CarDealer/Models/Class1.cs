using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarDealer.Models
{
	public enum Color
	{
		JetBlack=6,
		Cyan=7,
		Blue = 0,
		Yellow=1,
		Red=2,
		White=3,
		Black=4,
		None=5
	}

	public class Engine
	{
		public string Type { get; set; }
		public int Cylinders { get; set; }
	}

	[BsonIgnoreExtraElements]
	public class Car: ISupportInitialize // embedded (no id necessary)
	{
		public string Type { get; set; }
		public int Year { get; set; }
		[BsonRepresentation(BsonType.String)]
		public Color Color { get; set; }
		public Engine Engine { get; set; }

		[BsonIgnore]
		public Customer Customer { get; set; }

		//public Guid SillyId { get; set; }
		
		//[BsonExtraElements]
		//public BsonDocument AdditionalData { get; set; }

		public Car()
		{
			//SillyId = Guid.NewGuid();
		}

		public void BeginInit()
		{
		}

		public void EndInit()
		{
		}
	}

	public class ContactInfo
	{
		public string Name { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
	}


	public class Customer: ISupportInitialize // top level
	{
		public ObjectId Id { get; set; }
		public List<Car> Cars { get; set; }
		public ContactInfo ContactInfo { get; set; }

		public Customer()
		{
			Cars = new List<Car>();
			ContactInfo = new ContactInfo();
		}

		public void BeginInit()
		{
		}

		public void EndInit()
		{
			foreach (var c in this.Cars)
			{
				c.Customer = this;
			}
		}
	}


	public class Vehicle
	{
	}

	public class Dealer
	{
		public ObjectId Id { get; set; }
		public string Name { get; set; }
		
		[BsonDateTimeOptions(Kind=DateTimeKind.Local)]
		public DateTime Created { get; set; }

		[BsonDateTimeOptions(Kind = DateTimeKind.Local)]
		public DateTime? LastOrdered { get; set; }

		public Dealer()
		{
			// this.Created = DateTime.UtcNow;
			this.Created = DateTime.Now;
		}
	}

}






//namespace del
//{
	
//public class Rootobject
//{
//public Car[] Cars { get; set; }
//public Contactinfo ContactInfo { get; set; }
//}

//public class Contactinfo
//{
//public string City { get; set; }
//public string Country { get; set; }
//}

//public class Car
//{
//public string Type { get; set; }
//public int Year { get; set; }
//public int Color { get; set; }
//public Engine Engine { get; set; }
//}

//public class Engine
//{
//public string Type { get; set; }
//public int Cylinders { get; set; }
//}


//}



