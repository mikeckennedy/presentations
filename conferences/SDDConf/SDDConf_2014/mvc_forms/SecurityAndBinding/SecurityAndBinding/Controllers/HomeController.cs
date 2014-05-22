using SecurityAndBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityAndBinding.Controllers
{
    public class HomeController : Controller
    {
	    public HomeController()
	    {
			ViewBag.CurrentUser = WebUser.Current;
	    }

        public ActionResult Index()
        {
	        return View(WebUser.All());
        }

		[HttpGet]
		public ActionResult Edit()
		{
			return View(WebUser.Current);
		}

		[HttpPost]
		public ActionResult Edit(object ignoreHereToCompile)
		{
			if (!TryUpdateModel(WebUser.Current))
			{
				return View(WebUser.Current);
			}

			return Redirect("/");
		}

		[HttpGet]
		public ActionResult EditOther(int id = -1)
		{
			WebUser user = WebUser.All().Single(u => u.Id == id);
			return View("Edit", user);
		}

		[HttpPost]
		public ActionResult EditOther(WebUser otherUser, int id = -1)
		{
			if (!ModelState.IsValid)
			{
				return View("Edit", otherUser);
			}

			WebUser.Save(otherUser);
			return Redirect("/");
		}

    }
}
