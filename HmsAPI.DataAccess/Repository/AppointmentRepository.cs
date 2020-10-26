using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public void DeleteAppointment(int AppointmentID)
        {
            try
            {
                var objAppointment = GetAppointmentByID(AppointmentID);
                Delete(objAppointment);
            }
            catch(Exception ex)
            {
                RollbackTransaction();
            }
        }

        public Appointment GetAppointmentByID(int AppointmentID)
        {
            var session = FluentNHibernateHelper.OpenSession();
            var objAppointment = session.Query<Appointment>().Where(x => x.AppointmentID == AppointmentID).FirstOrDefault();
            return objAppointment;
        }
    }
}
