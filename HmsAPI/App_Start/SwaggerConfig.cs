using System.Web.Http;
using WebActivatorEx;
using HmsAPI;
using Swashbuckle.Application;

using System.Linq;

namespace HmsAPI
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.EnableSwagger(c => {
                c.SingleApiVersion("v2", "HMS.APi");                
            }).EnableSwaggerUi(c => { });
        }
    }
  }

