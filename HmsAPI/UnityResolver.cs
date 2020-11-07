using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Unity;

namespace HmsAPI
{
    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer container;
        public UnityResolver(IUnityContainer unityContainer)
        {
            if (unityContainer == null)
                throw new ArgumentNullException("Container shouldnot be null");             

             container = unityContainer;

        }
        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch(Exception ex)
            {
                return null;

            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException ex)
            {
                return new List<object>();

            }
        }

        public object GetInstance(Type serviceType)
        {

            try
            {
                if (container.IsRegistered(serviceType))
                {
                    return container.Resolve(serviceType);
                }
                return null;

            }
            catch (Exception ex)
            {
                return null;

            }
        }
    }
}
