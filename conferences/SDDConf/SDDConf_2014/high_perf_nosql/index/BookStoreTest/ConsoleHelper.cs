using System;

namespace BookStoreTest
{
	class ConsoleHelper
	{
		public static void Message(string msg)
		{
			using (new ConsoleColorContext(ConsoleColor.Cyan))
			{
				Console.WriteLine(msg);
			}
		}

		public static void Prompt(string prompt)
		{

			using (new ConsoleColorContext(ConsoleColor.Yellow))
			{
				Console.WriteLine(prompt);
				Console.ReadKey(true);
			}
		}
	}
}