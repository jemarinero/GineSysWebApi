using Newtonsoft.Json.Serialization;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Http.Cors;
using System.Net.Http.Headers;
using Newtonsoft.Json.Converters;

namespace GineSys
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/plain"));
            var dateTimeConverter = new IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
            };

            config.Formatters
                .JsonFormatter
                .SerializerSettings
                .Converters.Add(dateTimeConverter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
