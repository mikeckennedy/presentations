using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace improving_mvc_projects.Models
{
	public class Repository : IDisposable

	{
		public string[] GetBlogTitles()
		{
			return new[]
			{
				"First post",
				"Second post",
				"Third post",
			};
		}

		public void Dispose()
		{
			Debug.WriteLine("Thanks for cleaning me up!!!");
		}
	}
}