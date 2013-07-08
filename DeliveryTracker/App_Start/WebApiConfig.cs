﻿using System.Web.Http;

namespace DeliveryTracker
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.Routes.MapHttpRoute(
					name: "DefaultApi",
					routeTemplate: "{controller}/{id}",
					defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
