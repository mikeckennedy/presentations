using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace improving_mvc_projects.Controllers
{
	[RoutePrefix("posts")]
	public class PostController : BaseController
	{
		[Route("show/{year:int}/{month:int}/{day:int}/{title}")]
		public ActionResult Show(int year, int month, int day, string title)
		{
			DateTime postDate = new DateTime(year, month, day);
			return Content(string.Format("Would show {0} from {1}",
				title, postDate));
		}
	}
}