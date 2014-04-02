using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevWeekBlogger.Controllers
{
    public abstract class BloggerBaseController : Controller
    {
		protected DataContext dataContext = new DataContext();

	    protected override void Dispose(bool disposing)
	    {
		    base.Dispose(disposing);
			dataContext.Dispose();
	    }
    }

	public class DataContext : IDisposable
	{

		public void Dispose()
		{
		}
	}
}