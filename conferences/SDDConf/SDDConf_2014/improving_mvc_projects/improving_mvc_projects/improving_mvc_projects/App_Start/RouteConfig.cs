using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace improving_mvc_projects
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapMvcAttributeRoutes();

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}/{name}",
				defaults: new
				{
					controller = "Home", 
					action = "Index", 
					id = UrlParameter.Optional,
					name = UrlParameter.Optional
				}
			);
		}
	}
}
