﻿using PostEngine.Logic.Services;
using PostEngine.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using PostEngine.Logic;
using PostEngine.Logic.Utilities;

namespace PostEngine
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web            
            config.DependencyResolver = new UnityResolver();

            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            formatters.JsonFormatter.Indent = true;
            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
