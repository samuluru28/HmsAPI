using HmsAPI.DataAccess;
using HmsAPI.Dto;
using HmsAPI.Model;
using HmsAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services
{
    public class AppointmentService: IAppointmentService
    {
        public readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;

        }
        public AppointmentDTO AddAppointment(AppointmentDTO obj)
        {
            var objAppointment = ConvertTOModel(obj);
            var appointment = _appointmentRepository.SaveorUpdate(objAppointment);
            return ConvertTODTO(appointment);
        }

        public AppointmentDTO GetAppointmentByID(int appointmentID)
        {
            var appointment = _appointmentRepository.GetAppointmentByID(appointmentID);
            return ConvertTODTO(appointment);
        }

        public IEnumerable<AppointmentDTO> GetAllAppointments()
        {
            List<AppointmentDTO> appointmentDTOList = new List<AppointmentDTO>();
            IEnumerable<Appointment> appointmentDTOS = _appointmentRepository.GetAll();
            foreach (var appointment in appointmentDTOS)
            {
                var appointmentDTO = ConvertTODTO(appointment);
                appointmentDTOList.Add(appointmentDTO);

            }
            return appointmentDTOList;
        }
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
