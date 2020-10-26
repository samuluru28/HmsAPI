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
        static void Main(string[] args)
        {

            HostFactory.Run(x => {
                x.Service<RestService>(s => {
                    s.ConstructUsing(() => new RestService());
                    s.WhenStarted(rs => rs.Start());
                    s.WhenStopped(rs => rs.Stop());
                    s.WhenShutdown(rs => rs.Stop());
                });
                x.RunAsLocalSystem();
                x.StartAutomatically();
                x.SetServiceName("WebAPiTest");
                x.SetDisplayName("WebAPiTest");
                x.SetDescription("Sample WebAPi");
            });
        }

        public class RestService
        {
            private IDisposable appDisposable;
            public void Start()
            {
                appDisposable = WebApp.Start<Startup>("http://localhost:8085");
            }

            public void Stop()
            {
                if (appDisposable != null)
                {
                    appDisposable.Dispose();
                }
            }
        }
        //string baseAddress = "http://localhost:9000/";
        //    using (WebApp.Start<Startup>(url: baseAddress))
        //    {
        //        HttpClient client = new HttpClient();

        //        var response = client.GetAsync(baseAddress + "api/home").Result;

        //        Console.WriteLine(response);
        //        Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        //        Console.ReadLine();
        //    }



    }
    }

    

