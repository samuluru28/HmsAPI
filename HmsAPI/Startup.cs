using HmsAPI.DataAccess;
using HmsAPI.Model;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using NHibernate.Transaction;
using System.IO;
using System.Reflection;
using Microsoft.Practices.Unity;

namespace HmsAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);


            var assemblies = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll").Select(x=> Assembly.LoadFile(x)).ToArray<Assembly>();
            var container = new UnityContainer();
            container.RegisterTypes(AllClasses.FromAssemblies(assemblies),WithMappings.FromMatchingInterface,WithName.Default,WithLifetime.None,null,true
                );
            config.DependencyResolver = new UnityResolver(container);
            appBuilder.UseWebApi(config);
            SwaggerConfig.Register(config);
           
        }
    }
}
