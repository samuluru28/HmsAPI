using Microsoft.Practices.Unity;
using System;
using System.IO;
using System.Reflection;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using System.Linq;

namespace HmsAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            var assemblies = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "Hms*.dll").Select(x => Assembly.LoadFile(x)).ToArray<Assembly>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterTypes(AllClasses.FromAssemblies(assemblies), WithMappings.FromMatchingInterface, WithName.Default, WithLifetime.None, null, true
               );
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
        }
    }
}