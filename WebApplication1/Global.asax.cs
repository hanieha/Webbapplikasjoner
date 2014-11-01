using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route Navn
                "{controller}/{action}/{id}", // Url med parametere
                new { controller = "Salg", action = "Index", id = UrlParameter.Optional } 
            );

        }
        protected void Application_Start()
        {
            System.Data.Entity.Database.SetInitializer(new WebApplication1.Model.SampleData());
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
           //** RouteConfig.RegisterRoutes(RouteTable.Routes);
            //System.Data.Entity.Database.SetInitializer<Nettbutikk>(new RecreateDatabaseIfModelChanges<Nettbutikk>());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
