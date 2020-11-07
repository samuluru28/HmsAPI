using HmsAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services.Interfaces
{
    public interface IAppointmentService
    {
        AppointmentDTO AddAppointment(AppointmentDTO obj);

        AppointmentDTO GetAppointmentByID(int appointmentID);

        List<AppointmentDTO> GetAllAppointments();
        List<DoctorAppointmentDTO> GetDoctorAppointmentByDate(int doctorID, DateTime date);
    }
}
