using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore;
using MongoDB.Driver;

namespace BookStoreTest
{
	class OurMongoHelper
	{
		public static void EnableProfiling(int slowMs)
		{
			BookStoreContext mongo = new BookStoreContext();
			mongo.Database.SetProfilingLevel(ProfilingLevel.Slow, TimeSpan.FromMilliseconds(slowMs));
		}

		public static void RemoveOldProfileData()
		{
			BookStoreContext mongo = new BookStoreContext();
			mongo.Database.SetProfilingLevel(ProfilingLevel.None);
			MongoCollection<SystemProfileInfo> coll =
				mongo.Database.GetCollection<SystemProfileInfo>("system.profile");
			coll.Drop();
		}
	}
}
