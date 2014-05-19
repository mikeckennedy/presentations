using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_forms_starter.core;

namespace mvc_forms_starter.Controllers
{
	public class BaseController : Controller
	{
		public Repository repository = Repository.Create();
	}
}