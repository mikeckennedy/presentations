using System;
using System.Linq;
using AggregationLib;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using Newtonsoft.Json;

namespace Program
{
	internal class Program
	{
		private static void Main()
		{
			ZipContext ctx = new ZipContext();
			var zips = ctx.Zips.AsQueryable(ExecutionTarget.AggregationFramework);

			Console.WriteLine("State with more than 5,000,000:");
			var states = zips
				.GroupBy(z => z.State)
				.Select(g => new { State = g.Key, Pop = g.Sum(z => z.Population) })
				.OrderByDescending(s => s.Pop)
				.Where(s => s.Pop > 5000000);

			foreach (var state in states)
			{
				Console.WriteLine("{0} has\t{1:N0}", state.State, state.Pop);
			}


			Console.WriteLine("Aggregation is:");
			Console.WriteLine(GetAggregationFrameworkModel(states));
			Console.WriteLine();
			Console.WriteLine();


			Console.WriteLine("states with most zip codes");
			var states2 = zips
				.GroupBy(z => z.State)
				.Select(g => new
				{
					State = g.Key,
					ZipCount = g.Count(),
				})
				.OrderByDescending(s => s.ZipCount);

			foreach (var state in states2.Take(5))
			{
				Console.WriteLine("{0} has\t{1:N0} zipcodes", state.State, state.ZipCount);
			}

			Console.WriteLine("Aggregation is:");
			Console.WriteLine(GetAggregationFrameworkModel(states2));
			Console.WriteLine();
			Console.WriteLine();


			Console.WriteLine("Cities with most zip codes");
			var cities = zips
				.GroupBy(z => z.City)
				.Select(g => new
				{
					City = g.Key,
					ZipCount = g.Count(),
				})
				.OrderByDescending(s => s.ZipCount);

			foreach (var state in cities.Take(5))
			{
				Console.WriteLine("{0} has\t{1:N0} zipcodes", state.City, state.ZipCount);
			}

			Console.WriteLine("Aggregation is:");
			Console.WriteLine(GetAggregationFrameworkModel(cities));
			Console.WriteLine();
			Console.WriteLine();

			Console.WriteLine("Average city size by state");
			var byState = zips
				.GroupBy(z => new { z.State, z.City })
				.Select(g => new
				{
					g.Key.State,
					g.Key.City,
					Pop = g.Sum(z => z.Population)
				})
				.GroupBy(u => u.State)
				.Select(s => new
				{
					State = s.Key,
					Ave = s.Average(u => u.Pop),
					Total = s.Sum(u => u.Pop),
					LargestCityPop = s.Max(u => u.Pop),
				})
				.OrderByDescending(u => u.Total);

			foreach (var v in byState.Take(5))
			{
				Console.WriteLine("{0} has ave pop {1:N0} and total pop {2:N0}, largest city is {3:N0}.", v.State, v.Ave, v.Total,
					v.LargestCityPop);
			}

			Console.WriteLine("Aggregation is:");
			Console.WriteLine(GetAggregationFrameworkModel(byState));
			Console.WriteLine();
			Console.WriteLine();


			Console.WriteLine("States and their largest cities");
			var spc =
				zips.GroupBy(z => new { z.State, z.City })
					.Select(g => new { g.Key.City, g.Key.State, Pop = g.Sum(z => z.Population) })
					.OrderByDescending(cs => cs.Pop)
					.GroupBy(g => g.State)
					.Select(s => new { State = s.Key, s.First().City, s.First().Pop })
					.OrderByDescending(s => s.Pop);


			foreach (var v in spc.Take(5))
			{
				Console.WriteLine("{0} biggest city is {1} with total pop {2:N0}.",
					v.State, v.City, v.Pop);
			}

			Console.WriteLine("Aggregation is:");
			Console.WriteLine(GetAggregationFrameworkModel(byState));
			Console.WriteLine();
			Console.WriteLine();


			Console.WriteLine("States with most cities");
			var statesAndCityCount =
				zips.GroupBy(z => new { z.State, z.City })
					.Select(s => new { s.Key.State })
					.GroupBy(cs => cs.State)
					.Select(s => new { State = s.Key, Cities = s.Count() })
					.OrderByDescending(s => s.Cities);

			foreach (var v in statesAndCityCount.Take(5))
			{
				Console.WriteLine("{0} has {1:N0} cities.",
					v.State, v.Cities);
			}


			Console.Read();
		}


		protected static string GetAggregationFrameworkModel<T>(IQueryable<T> query)
		{
			var model = ((LingToMongoQueryable<T>)query).BuildQueryModel();
			var agg = (AggregationFrameworkModel)model;

			return GetPrettyPrintedJson(agg.ToBsonDocument().ToString());
		}


		public static string GetPrettyPrintedJson(string json)
		{
			dynamic parsedJson = JsonConvert.DeserializeObject(json);
			return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
		}
	}
}