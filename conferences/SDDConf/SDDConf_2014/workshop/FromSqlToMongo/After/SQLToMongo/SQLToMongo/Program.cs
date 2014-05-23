using System;
using System.Linq;
using MongoDB.Bson;
using NorthwindMongo;
using NorthwindSQL;

namespace SQLToMongo
{
    class Program
    {
		static void Main()
		{
			try
			{
				Run();
			}
			catch (NotImplementedException)
			{
				Console.ForegroundColor = ConsoleColor.Red;

				Console.WriteLine("Looks like you are not done yet!");
			}
		}

		private static void Run()
		{
			Console.WriteLine("starting import...");
			var mongo = new NorthwindContext();
			using (var entities = new northwindEntities())
			{
				Console.WriteLine("Importing relational DB from: " + entities.Database.Connection.DataSource);
				
				ImportCategories(entities, mongo);
				ImportSuppliers(entities, mongo);
				ImportProducts(entities, mongo);
				ImportCustomers(entities, mongo);
			
				Console.WriteLine("Import done");
			}

			Console.WriteLine();
			const string catName = "Seafood";
			Console.WriteLine(catName + " products:");
			var category = mongo.Categories.Single(c => c.CategoryName == catName);
			var products = mongo.Products.Where(p => p.CategoryID == category.Id);
			foreach (var p in products)
			{
				Console.WriteLine("\t{0} (${1:N2})", p.ProductName, p.UnitPrice);
			}
			
			Console.WriteLine();
			const string supplierCountry = "USA";
			Console.WriteLine(supplierCountry + " products");
			ObjectId?[] supplierIds =
				(from s in mongo.Suppliers
				 where s.Country == supplierCountry
				 select new ObjectId?(s.Id)).ToArray();

			var supplierProducts =
				(from p in mongo.Products
				 where supplierIds.Contains(p.SupplierID)
				 orderby p.ProductName
				 select p);

			foreach (var p in supplierProducts)
			{
				Console.WriteLine("\t{0} (${1:N2})", p.ProductName, p.UnitPrice);
			}
			Console.WriteLine();

			DateTime afterDate = new DateTime(1998, 1, 1);
			Console.WriteLine("ordered after " + afterDate.ToShortDateString());
			var customers =
				from c in mongo.Customers
				where c.Orders.Any(o => o.OrderDate > afterDate)
				select c;
			foreach (var customer in customers)
			{
				Console.WriteLine("\t{0}", customer.ContactName);
			}
			Console.WriteLine();

			Console.Write("Most expensive product: ");
			var prod = mongo.Products.OrderByDescending(p => p.UnitPrice).First();
			Console.WriteLine(prod.ProductName);
			Console.WriteLine();

			Console.WriteLine("Who order this product?");
			var bigFish =
				from c in mongo.Customers
				where c.Orders.Any(o => o.OrderDetails
					.Any(od => od.ProductID == prod.Id))
				select c;

			foreach (var b in bigFish)
			{
				Console.WriteLine("\t{0}", b.ContactName);
			}

			Console.WriteLine("done");
			Console.Read();
		}

		private static void ImportCustomers(northwindEntities entities, NorthwindContext mongo)
		{
			mongo.Clear<Customer>();
			foreach (var c in entities.Customers)
			{
				var mc = new NorthwindMongo.Models.Customer();

				mc.SqlId = c.CustomerID;
				mc.Address =  c.Address;
				mc.City =  c.City;
				mc.CompanyName =  c.CompanyName;
				mc.ContactName =  c.ContactName;
				mc.ContactTitle =  c.ContactTitle;
				mc.Country =  c.Country;
				mc.Fax =  c.Fax;
				mc.Phone =  c.Phone;
				mc.PostalCode =  c.PostalCode;
				mc.Region =  c.Region;

				foreach (var o in c.Orders)
				{
					var mo = new NorthwindMongo.Models.Order();
					mo.Id = GetObjectId(o.OrderID);
					mo.Freight =  o.Freight;
					mo.OrderDate =  o.OrderDate;
					mo.RequiredDate =  o.RequiredDate;
					mo.ShipAddress =  o.ShipAddress;
					mo.ShipCity =  o.ShipCity;
					mo.ShipCountry =  o.ShipCountry;
					mo.ShipName =  o.ShipName;
					mo.ShipPostalCode =  o.ShipPostalCode;
					mo.ShipRegion =  o.ShipRegion;
					mo.ShipVia =  o.ShipVia;
					mo.ShippedDate =  o.ShippedDate;

					foreach (var od in o.Order_Details)
					{
						var mod = new NorthwindMongo.Models.OrderDetail();

						mod.ProductID = GetObjectId(od.ProductID);
						mod.Quantity = od.Quantity;
						mod.UnitPrice = od.UnitPrice;

						mo.OrderDetails.Add(mod);
					}

					mc.Orders.Add(mo);
				}

				mongo.Save(mc);
			}

		}

		private static void ImportProducts(
			northwindEntities entities, NorthwindContext mongo)
		{
			mongo.Clear<Product>();
			foreach (var product in entities.Products)
			{
				var mp = new NorthwindMongo.Models.Product();
				mp.Id = GetObjectId(product.ProductID);
				mp.CategoryID = GetObjectId(product.CategoryID);
				mp.Discontinued =  product.Discontinued;
				mp.ProductName =  product.ProductName;
				mp.QuantityPerUnit =  product.QuantityPerUnit;
				mp.ReorderLevel =  product.ReorderLevel;
				mp.SupplierID =  GetObjectId(product.SupplierID);
				mp.UnitPrice =  product.UnitPrice;
				mp.UnitsInStock =  product.UnitsInStock;
				mp.UnitsOnOrder =  product.UnitsOnOrder;

				mongo.Save(mp);
			}
		}

		private static void ImportSuppliers(
			northwindEntities entities, NorthwindContext mongo)
		{
			mongo.Clear<Supplier>();
			foreach (var supplier in entities.Suppliers)
			{
				var ms = new NorthwindMongo.Models.Supplier();
				ms.Id = GetObjectId(supplier.SupplierID);
				ms.Address =  supplier.Address;
				ms.City =  supplier.City;
				ms.CompanyName =  supplier.CompanyName;
				ms.ContactName =  supplier.ContactName;
				ms.ContactTitle =  supplier.ContactTitle;
				ms.Country =  supplier.Country;
				ms.Fax =  supplier.Fax;
				ms.HomePage =  supplier.HomePage;
				ms.Phone =  supplier.Phone;
				ms.PostalCode =  supplier.PostalCode;
				ms.Region =  supplier.Region;

				mongo.Save(ms);
			}
		}

		private static void ImportCategories
			(northwindEntities entities, NorthwindContext mongo)
		{
			foreach (var category in entities.Categories)
			{
				var mc = new NorthwindMongo.Models.Category();

				mc.Id = GetObjectId(category.CategoryID);
				mc.CategoryName = category.CategoryName;
				mc.Description = category.Description;
				mc.Picture = category.Picture;
				
				mongo.Save(mc);
			}
		}

        static ObjectId GetObjectId(int id)
        {
            string s = id.ToString();
            int len = ObjectId.Empty.ToString().Length;
            return new ObjectId(new String('0', len - s.Length) + s);
        }

        static ObjectId? GetObjectId(int? id)
        {
            if (id == null)
                return null;
            return GetObjectId(id.Value);
        }
    }
}
