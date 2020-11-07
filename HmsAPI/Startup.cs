using HmsAPI.DataAccess;
using HmsAPI.DataAccess.Interface;
using HmsAPI.DataAccess.Repository;
using HmsAPI.Services;
using HmsAPI.Services.Interfaces;
using Microsoft.Practices.Unity;
using Owin;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Unity;

namespace HmsAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            Console.WriteLine("Terst Configuration");
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();

            var assemblies = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "Hms*.dll").Select(x => Assembly.LoadFile(x)).ToArray<Assembly>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterTypes(AllClasses.FromAssemblies(assemblies), WithMappings.FromMatchingInterface, WithName.Default, WithLifetime.None, null, true
               );
            config.DependencyResolver = new UnityResolver(container);
            
            SwaggerConfig.Register(config);
            appBuilder.UseWebApi(config);
           
           
        }
    }
}
