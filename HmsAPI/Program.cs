using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace HmsAPI
{
    static class Program
    {
        public static void Main(string[] args)
        {

            HostFactory.Run(x =>
            {
                x.Service<RestService>(s =>
                {
                    s.ConstructUsing(() => new RestService());
                    s.WhenStarted(rs => rs.Start("http://localhost:9001"));
                    s.WhenStopped(rs => rs.Stop());                   
                });
                x.RunAsLocalSystem();
               // x.StartAutomatically();
                x.SetServiceName("WebAPiTest");
                x.SetDisplayName("WebAPiTest");
                x.SetDescription("Sample WebAPi");
            });
        }

        public class RestService
        {
            private IDisposable appDisposable;
            public void Start(string url)
            {
                appDisposable = WebApp.Start<Startup>(url);
                Console.WriteLine("Service started under http://localhost:9001");
            }

            public void Stop()
            {
                if (appDisposable != null)
                {
                    appDisposable.Dispose();
                }
            }
        }
    }
}

    

