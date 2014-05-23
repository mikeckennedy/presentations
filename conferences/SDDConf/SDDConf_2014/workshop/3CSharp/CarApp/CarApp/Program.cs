using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using CarApp.Data;
using MongoDB;


namespace CarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateCars();
            FixupChanges();
            ShowCars();
        }

        private static void FixupChanges()
        {
            var mongo = new MongoContext();
            foreach (var car in mongo.Cars)
            {
                mongo.Save(car);
            }
        }

        private static void ShowCars()
        {
            var mongo = new MongoContext();

            var cars =
                from c in mongo.Cars
                where c.Color == OurColor.None
                orderby c.Created descending 
                select c;

            Log(cars, "check for cars");

            if (cars.Any())
            {
                Console.WriteLine("Found some cars without color!");
                foreach (var car in cars)
                {
                    Console.Write("What color should {0} be?", car.Name);
                    string input = Console.ReadLine();

                    car.Color = (OurColor) Enum.Parse(typeof (OurColor), input, true);
                    mongo.Save(car);
                }
            }
            else
            {
                Console.WriteLine("All cars have color, here are the gas ones: ");
                var colorCars =
                    from c in mongo.Cars
                    where 
                        c.Color != OurColor.None && 
                        c.Engine.Type == "Gas"
                    orderby c.Engine.HP
                    select c;

                Log(colorCars, "find gas cars with color");

                foreach (var car in colorCars)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3}", car.Name,
                        car.Color, car.Engine.Type, car.Engine.HP);
                }
            }

        }

        private static void Log<T>(IEnumerable<T> q, string msg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            
            string query = q.ToMongoQueryText();


            Console.WriteLine("\t{0}: {1}", msg, query);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        private static void CreateCars()
        {
            MongoContext mongo = new MongoContext();

            if (mongo.Cars.Any())
            {
                Console.WriteLine("Data already added, skipping");
                return;
            }

            Console.WriteLine("Adding data...");

            Car c = new Car();
            c.Name = "Roadster";
           // c.Maker = "Tesla";
            c.Engine = new Engine() {Type="Electric", HP=350};
            c.ServiceRecords.Add(new ServiceRecord() {Desc="Oil change", Price=7.99});


            mongo.Save(c);
            
            c = new Car();
            c.Name = "Esprie";
           // c.Maker = "Lotus";
            c.Engine = new Engine() {Type="Gas", HP=300};
            mongo.Save(c);
            
            c = new Car();
            c.Name = "Station Wagon";
           // c.Maker = "Chevy";
            c.Engine = new Engine() {Type="Gas", HP=100};
            mongo.Save(c);
        }
    }
}
