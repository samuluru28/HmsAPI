using HmsAPI.DataAccess;
using HmsAPI.Dto;
using HmsAPI.Model;
using HmsAPI.Services.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services
{
    public class AppointmentService: IAppointmentService
    {
        private ILog log = LogManager.GetLogger(typeof(AppointmentService));
        public readonly IAppointmentRepository _appointmentRepository;
        public readonly IUserTableRepository _userTableRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository, IUserTableRepository userTableRepository)
        {
            _appointmentRepository = appointmentRepository;
            _userTableRepository = userTableRepository;

        }
        public AppointmentDTO AddAppointment(AppointmentDTO obj)
        {
            try
            {
                var objAppointment = ConvertTOModel(obj);
                var appointment = _appointmentRepository.SaveorUpdate(objAppointment);
                log.Info("Appointment Info saved Successfully");
                return ConvertTODTO(appointment);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Exception occured while Adding new Appointment Info Ex:{0}", ex.Message);
                return null;

            }
        }

        public AppointmentDTO GetAppointmentByID(int appointmentID)
        {
            try
            {
                var appointment = _appointmentRepository.GetAppointmentByID(appointmentID);
                return ConvertTODTO(appointment);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Exception occured while retrieving Appointment Info Ex:{0}", ex.Message);
                return null;

            }

        }

        public List<AppointmentDTO> GetAllAppointments()
        {
            try
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
            catch(Exception ex)
            {
                log.ErrorFormat("Exception occured while retrieving List of all Appointment Info Ex:{0}", ex.Message);
                return null;

            }
        }

        public List<DoctorAppointmentDTO> GetDoctorAppointmentByDate(int doctorID, DateTime date)
        {
            try
            {
                var doctorAppointmentList = new List<DoctorAppointmentDTO>();
                List<DoctorAppointment> appointments = _appointmentRepository.GetAppointments(doctorID, date);

                foreach (var app in appointments)
                {
                    var DoctorAppointmentDTO = new DoctorAppointmentDTO
                    {
                        AppointmentID = app.AppointmentID,
                        DoctorID = app.DoctorID,
                        UserID = app.UserID,
                        StartTime = app.StartTime,
                        EndTime = app.EndTime,
                        UserName = app.UserName,
                        HospitalName = app.HospitalName,
                        Date = app.Date

                    };
                    doctorAppointmentList.Add(DoctorAppointmentDTO);

                }

                return doctorAppointmentList;
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Exception occured while retrieving Appointment Info by DoctorId and Date Ex:{0}", ex.Message);
                return null;

            }
        }

        public Appointment ConvertTOModel(AppointmentDTO obj)
        {

            var appointment = new Appointment()
            {
                AppointmentID = obj.AppointmentID,
                DoctorCalendarID = obj.DoctorCalendarID,
                DoctorID = obj.DoctorID,
                AppDate = obj.AppDate,
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
                AppDate=obj.AppDate,
                UserID = obj.UserID,
                StartTime = obj.StartTime,
                EndTime = obj.EndTime

            };
            return appointmentDTO;
        }

      
        
    }
}
