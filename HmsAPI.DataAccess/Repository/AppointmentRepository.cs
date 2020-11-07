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
        public void DeleteAppointment(int appointmentID)
        {

            var objAppointment = GetAppointmentByID(appointmentID);
            Delete(objAppointment);
        }

        public Appointment GetAppointmentByID(int appointmentID)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var objAppointment = session.Query<Appointment>().Where(x => x.AppointmentID == appointmentID).FirstOrDefault();
                    return objAppointment;
                }
            }
        }

        public List<Appointment> GetAppointmentByUserID(int userID)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var objAppointment = session.Query<Appointment>().Where(x => x.UserID == userID).ToList();
                    return objAppointment;
                }
            }


        }

        public List<DoctorAppointment> GetAppointments(int doctorID, DateTime date)
        {


            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var query = "select d.DoctorID,a.UserID,a.AppointmentID,(u.FirstName + ' ' + u.LastName ) as UserName, a.StartTime,a.EndTime,h.Name,dc.Date from Doctor d" +
                                    "join Appointment a on d.DoctorID = a.DoctorID" +
                                    "join DoctorCalendar dc on dc.DoctorID = a.DoctorID" +
                                    "join Hospital h on h.HospitalID = dc.HospitalID" +
                                    "join UserTable u on u.UserID = a.UserID" +
                                     "where AppointmnetDate =" + date + "and d.doctorId =" + doctorID;

                    var results = session.CreateSQLQuery(query).AddEntity(typeof(DoctorAppointment)).List<DoctorAppointment>().ToList();
                    return results;
                }

            }


        }

        public List<Appointment> GetAppointmentsByDoctorID(int doctorID, DateTime date)
        {


            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var objAppointment = session.Query<Appointment>().Where(x => x.DoctorID == doctorID && x.AppDate == date).ToList();                  
                    return objAppointment;
                }

            }


        }
    }
}
