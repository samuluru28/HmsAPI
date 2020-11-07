using System.Web.Http;
using WebActivatorEx;
using HmsAPI;
using Swashbuckle.Application;

using System.Linq;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace HmsAPI
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.EnableSwagger(c => {
                c.SingleApiVersion("v1", "Name.APi");
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            }).EnableSwaggerUi(c => { });
        }
    }
  }

