using HmsAPI.Dto;
using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services
{
    public class AppointmentService
    {
        public Appointment ConvertTOModel(AppointmentDTO obj)
        {

            var appointment = new Appointment()
            {
                AppointmentID = obj.AppointmentID,
                DoctorCalendarID = obj.DoctorCalendarID,
                DoctorID = obj.DoctorID,
                UserID = obj.UserID,
                StartTime= obj.StartTime,
                EndTime = obj.EndTime

            };
            return appointment;
        }

        public AppointmentDTO ConvertTODTO(Appointment obj)
        {

            var appointmentDTO = new AppointmentDTO()
            {
                AppointmentID = obj.AppointmentID,
                DoctorCalendarID = obj.DoctorCalendarID,
                DoctorID = obj.DoctorID,
                UserID = obj.UserID,
                StartTime = obj.StartTime,
                EndTime = obj.EndTime

            };
            return appointmentDTO;
        }
    }
}
