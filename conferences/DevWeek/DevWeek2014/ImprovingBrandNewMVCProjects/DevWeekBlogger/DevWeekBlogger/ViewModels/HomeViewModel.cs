using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevWeekBlogger.ViewModels
{
	public class HomeViewModel
	{
		public string[] Posts { get; set; }
		public int CurrentPage { get; set; }
		public int TotalPages { get; set; }
	}
}