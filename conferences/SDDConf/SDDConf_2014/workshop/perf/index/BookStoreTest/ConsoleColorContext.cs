using System;
using System.Linq;

namespace BookStoreTest
{
	internal class ConsoleColorContext : IDisposable
	{
		public ConsoleColor ActiveColor { get; set; }
		public ConsoleColor OldColor { get; set; }

		public ConsoleColorContext(ConsoleColor activeColor)
		{
			OldColor = Console.ForegroundColor;
			ActiveColor = activeColor;
			Console.ForegroundColor = activeColor;
		}

		public void Dispose()
		{
			Console.ForegroundColor = OldColor;
		}
	}
}