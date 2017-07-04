using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace iassetTechnicalTest.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "SearchByCountryName",
                routeTemplate: "api/{controller}/{id}/{countryName}",
                defaults: new { id = RouteParameter.Optional, countryName = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "GetWeatherByCity",
                routeTemplate: "api/{controller}/{id}/{countryName}/{cityName}",
                defaults: new { id = RouteParameter.Optional, countryName = RouteParameter.Optional }
            );
        }
    }
}
