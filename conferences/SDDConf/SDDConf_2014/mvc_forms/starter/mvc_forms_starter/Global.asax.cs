using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using mvc_forms_starter.core;
using mvc_forms_starter.core.Models;

namespace mvc_forms_starter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

	        CreateSampleData();
        }

	    private void CreateSampleData()
	    {
		    Repository r = Repository.Create();

		    if (r.Categories.Count > 0)
			    return;

			r.AddCategory(new Category() { Id = 1, Name = "Science", ImageUrl = "https://i.chzbgr.com/maxW500/7568480768/hC5E9BACA/" });
			r.AddCategory(new Category() { Id = 2, Name = "Math", ImageUrl = "http://twistedphysics.typepad.com/cocktail_party_physics/images/2008/05/08/pythagoracatbox.jpg" });
			r.AddCategory(new Category() { Id = 3, Name = "Startups", ImageUrl = "http://scientopia.org/img-archive/scicurious/img_874.jpg" });
	    }
    }
}
