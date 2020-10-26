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
           
                var objAppointment = GetAppointmentByID(AppointmentID);
                Delete(objAppointment);
        }

        public Appointment GetAppointmentByID(int AppointmentID)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using(var session = sessionWrapper.Session)
                {
                    var objAppointment = session.Query<Appointment>().Where(x => x.AppointmentID == AppointmentID).FirstOrDefault();
                    return objAppointment;
                }
            }               
        }
    }
}
