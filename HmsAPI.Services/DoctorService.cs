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
    public class DoctorService : IDoctorService
    {
        private ILog log = LogManager.GetLogger(typeof(DoctorService));

        public readonly IDoctorRepository _doctorRepository;
        public readonly IDoctorCalendarRepository _doctorCalendarRepository;

        public readonly IAppointmentRepository _appointmentRepository;

        public DoctorService(IDoctorRepository doctorRepository, IDoctorCalendarRepository doctorCalendarRepository, IAppointmentRepository appointmentRepository)
        {
            _doctorRepository = doctorRepository;
            _doctorCalendarRepository = doctorCalendarRepository;
            _appointmentRepository = appointmentRepository;

        }


        public DoctorDTO AddDoctor(DoctorDTO obj)
        {
            try
            {
                var objDoctor = ConvertTOModel(obj);
                var doctor = _doctorRepository.SaveorUpdate(objDoctor);
                log.Info("Doctor info Added Successfully");
                return ConvertTODTO(doctor);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Exception occured while Adding new Doctor Info Ex:{0}", ex.Message);
                return null;

            }

        }

        public DoctorDTO GetDoctorsByID(int doctorID)
        {
            try
            {
                var doctor = _doctorRepository.GetDoctorByID(doctorID);
                return ConvertTODTO(doctor);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Exception occured while retreiving  Doctor Information Ex:{0}", ex.Message);
                return null;
            }
        }

        public List<DoctorDTO> GetDoctorsByHospitalID(int hospitalID)
        {
            try
            {
                List<DoctorDTO> doctorDTOList = new List<DoctorDTO>();
                IEnumerable<Doctor> doctor = _doctorRepository.GetDoctorsByHospitalID(hospitalID);
                foreach (var item in doctor)
                {
                    var doctorDTO = ConvertTODTO(item);
                    doctorDTOList.Add(doctorDTO);

                }
                return doctorDTOList;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Exception occured while retrieving  Doctor Information Ex:{0}", ex.Message);
                return null;
            }
        }
        public List<DoctorDTO> GetDoctorsByspecialization(string specialist)
        {
            try
            {
                List<DoctorDTO> doctorDTOList = new List<DoctorDTO>();
                IEnumerable<Doctor> doctor = _doctorRepository.GetDoctorsBySpecialization(specialist);
                foreach (var item in doctor)
                {
                    var doctorDTO = ConvertTODTO(item);
                    doctorDTOList.Add(doctorDTO);

                }
                return doctorDTOList;
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Exception occured while retrieving List of Doctor Information by Specialization Ex:{0}", ex.Message);
                return null;

            }

        }

        public List<DoctorDTO> GetAllDoctors()
        {
            try
            {
                List<DoctorDTO> doctorDTOList = new List<DoctorDTO>();
                IEnumerable<Doctor> doctorDTO = _doctorRepository.GetAll();
                foreach (var doctor in doctorDTO)
                {
                    var objdoctorDTO = ConvertTODTO(doctor);
                    doctorDTOList.Add(objdoctorDTO);

                }
                return doctorDTOList;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Exception occured while retrieving List of Doctor Information Ex:{0}", ex.Message);
                return null;

            }
        }

        public List<DoctorAvailabilityDTO> GetDoctorAvailability(int doctorID, DateTime date, int hospitalID)
        {
            try
            {
                List<DoctorAvailabilityDTO> doctorAvailabilityDTOList = new List<DoctorAvailabilityDTO>();

                IEnumerable<DoctorCalendar> doctorCalendarDTO = _doctorCalendarRepository.GetDoctorCalendar(doctorID, date, hospitalID);
                //var appointements  = getapoointmnetbydoctorcalendarid()

                foreach (var item in doctorCalendarDTO)
                {
                    var doctorAppointments = _appointmentRepository.GetAppointmentsByDoctorID(item.DoctorID, item.Date);
                    var startTime = item.StartTime;// item.starttime-10AM
                    var endTime = item.StartTime.AddMinutes(15); //item.endtime = 11am
                    while (endTime <= item.EndTime)
                    {
                        bool availability = !doctorAppointments.Where(x => x.EndTime == endTime && x.StartTime == startTime).Any();

                        var objDTO = new DoctorAvailabilityDTO
                        {
                            DoctorCalendarID = item.DoctorCalendarID,
                            Date = item.Date,
                            DoctorID = item.DoctorID,
                            StartTime = startTime,
                            EndTime = endTime,
                            IsAvailable = availability

                        };

                        doctorAvailabilityDTOList.Add(objDTO);
                        startTime = endTime;
                        endTime = endTime.AddMinutes(15);

                    }
                }
                return doctorAvailabilityDTOList;
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Exception occured while retrieving List of DoctorAvailability Information Ex:{0}", ex.Message);
                return null;

            }

        }


        public Doctor ConvertTOModel(DoctorDTO obj)
        {

            var doctor = new Doctor()
            {
                DoctorID = obj.DoctorID,
                UserID = obj.UserID,
                Active = obj.Active,
                Specialist = obj.Specialist,
                LicenseNumber = obj.LicenseNumber,
                VerifiedBy = obj.VerifiedBy

            };
            return doctor;
        }

        public DoctorDTO ConvertTODTO(Doctor obj)
        {

            var doctorDTO = new DoctorDTO()
            {
                DoctorID = obj.DoctorID,
                UserID = obj.UserID,
                Active = obj.Active,
                Specialist = obj.Specialist,
                LicenseNumber = obj.LicenseNumber,
                VerifiedBy = obj.VerifiedBy

            };
            return doctorDTO;
        }


    }
}
