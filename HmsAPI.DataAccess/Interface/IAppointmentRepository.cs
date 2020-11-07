using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HmsAPI.Model;

namespace HmsAPI.DataAccess
{
    public interface IAppointmentRepository
    {
        Appointment SaveorUpdate(Appointment obj);
        IEnumerable<Appointment> GetAll();

        Appointment GetAppointmentByID(int AppointmentID);

        void DeleteAppointment(int AppointmentID);
        List<Appointment> GetAppointmentByUserID(int userID);
        List<DoctorAppointment> GetAppointments(int doctorID, DateTime date);
        List<Appointment> GetAppointmentsByDoctorID(int doctorID, DateTime date);
    }
}
