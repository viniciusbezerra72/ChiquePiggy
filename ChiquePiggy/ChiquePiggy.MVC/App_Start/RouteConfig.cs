﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ChiquePiggy.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
        name: "BaixaPontuacao",
        url: "Caixa/",
        defaults: new { controller = "Caixa", action = "BaixaPontuacao", id = UrlParameter.Optional }
    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Caixa", action = "Inicio", id = UrlParameter.Optional }
            );
        }
    }
}
