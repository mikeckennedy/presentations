using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using improving_mvc_projects.Models;

namespace improving_mvc_projects.Controllers
{
	public class BaseController : Controller
	{
		protected Repository repository = new Repository();

		protected override void Dispose(bool disposing)
		{
			repository.Dispose();
			base.Dispose(disposing);
		}
	}
}