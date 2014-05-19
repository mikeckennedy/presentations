using System;
using System.Linq;
using System.Web.Mvc;

namespace mvc_forms_starter.Controllers
{
	public class HomeController : BaseController
	{
		// Step 1: Make view strongly typed.
		public ActionResult Index()
		{
			return View(this.repository.Categories);
		}
	}
}