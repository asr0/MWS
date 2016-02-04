using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web;
using System.Web.Configuration;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

namespace MWS.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            var container = new UnityContainer();

            //ConfigureDependencyInjection(config, container);

            ConfigureWebApi(config);

            //ConfigureOAuth(app, container.Resolve<IUserApplicationService>());

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public static void ConfigureWebApi(HttpConfiguration config)
        {
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);
            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name:"DefaultApi",
                routeTemplate:"api/{controller}/{id}",
                defaults:new  { id = RouteParameter.Optional}
                );
        }

    }
}