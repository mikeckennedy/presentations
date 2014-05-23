using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreTest
{
	class Perf
	{
		public static double Timed(Action action)
		{
			Stopwatch sw = Stopwatch.StartNew();
			action();
			sw.Stop();

			return sw.ElapsedMilliseconds;
		}
	}
}
