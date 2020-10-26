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

            appBuilder.UseWebApi(config);
            SwaggerConfig.Register(config);
            var session = FluentNHibernateHelper.OpenSession();
            var roles = session.Query<Roles>().ToList();
            var loginHistory = session.Query<LoginHistory>().ToList();
            var doctor = session.Query<Doctor>().ToList();
            var doctorCalendar = session.Query<DoctorCalendar>().ToList();
            var appointment = session.Query<Appointment>().ToList();
            var patientMedicine = session.Query<PatientMedicine>().ToList();

            //Roles obj = new Roles() { Name = "Test" };
            //session.SaveOrUpdate(obj);
            //var transaction = session.BeginTransaction();
            //var x= session.Get<Roles>(4);

            //session.Delete(x);

            //transaction.Commit();

        }
    }
}
