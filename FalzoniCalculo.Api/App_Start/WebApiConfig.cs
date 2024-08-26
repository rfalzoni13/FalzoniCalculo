using Newtonsoft.Json;
using System.Web.Http;

namespace FalzoniCalculo.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API Configuration And Services

            // Web API Routes config
            config.MapHttpAttributeRoutes();

            // Redirect to Swagger
            config.Routes.MapHttpRoute(
                name: "Swagger",
                routeTemplate: string.Empty,
                defaults: null,
                constraints: null,
                handler: new Swashbuckle.Application.RedirectHandler((message => message.RequestUri.ToString()), "swagger")
            );

            // Route Default Config
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Enable Cors
            config.EnableCors();

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
        }
    }
}
