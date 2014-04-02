using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevWeekBlogger.Controllers
{
	[RoutePrefix("posts")]
	public class PostsController : BloggerBaseController
	{
		[Route("{year:int}/{month:int}/{day:int}/{title}")]
		public ActionResult Show(int year, int month, int day, string title)
		{
			return Content("Would have shown " + title + " for " + new DateTime(year, month, day));
		}
		//[Route("{year:int}/{month:int}/{day:int}/{title}")]
		//public ActionResult Show2(int year, int month, int day, string title)
		//{
		//	return Content("Would have shown " + title + " for " + new DateTime(year, month, day));
		//}
	}
}