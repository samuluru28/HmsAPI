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
    }
}
