#region

using System.Web.Http;
using Microsoft.Owin.Cors;
using Microsoft.Practices.Unity;
using MWS.Api.Helpers;
using MWS.CrossCutting;
using MWS.NucleoCompartilhado.Eventos.Contratos;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

#endregion

namespace MWS.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var container = new UnityContainer();
            ConfigureDependencyInjection(config, container);
            ConfigureWebApi(config);
            //ConfigureOAuth(app, container.Resolve<IUserApplicationService>());
            app.UseCors(CorsOptions.AllowAll);
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
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
                );
        }

        public static void ConfigureDependencyInjection(HttpConfiguration config, UnityContainer container)
        {
            DependencyRegister.Register(container);
            config.DependencyResolver = new UnityResolverHelper(container);
            EventoDominio.Container = new DomainEventsContainer(config.DependencyResolver);
        }
    }
}