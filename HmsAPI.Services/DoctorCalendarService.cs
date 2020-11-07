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
    public class DoctorCalendarService: IDoctorCalendarService
    {
        private ILog log = LogManager.GetLogger(typeof(DoctorCalendarService));

        public readonly IDoctorCalendarRepository _doctorCalendarRepository;
        public DoctorCalendarService(IDoctorCalendarRepository doctorCalendarRepository)
        {
            _doctorCalendarRepository = doctorCalendarRepository;
        }

        public DoctorCalendarDTO AddDoctorCalender(DoctorCalendarDTO obj)
        {
            try
            {
                var objDoctorCalendar = ConvertTOModel(obj);
                var results = _doctorCalendarRepository.SaveorUpdate(objDoctorCalendar);
                return ConvertTODTO(results);
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Exception occured while Adding new DoctorCalendar Info Ex:{0}", ex.Message);
                return null;
            }

        }

        public DoctorCalendarDTO GetDoctorCalendarByID(int doctorCalendarID)
        {
            try
            {
                var doctorCalendar = _doctorCalendarRepository.GetDoctorCalendarByID(doctorCalendarID);

                return ConvertTODTO(doctorCalendar);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Exception occured while retrieving DoctorCalendar Info Ex:{0}", ex.Message);
                return null;
            }

        }

        public List<DoctorCalendarDTO> GetAllDoctorsCalendar()
        {
            try
            {
                List<DoctorCalendarDTO> doctorCalendarDTOList = new List<DoctorCalendarDTO>();
                IEnumerable<DoctorCalendar> doctorCalendar = _doctorCalendarRepository.GetAll();
                foreach (var calendar in doctorCalendar)
                {
                    var doctorCalendarDTO = ConvertTODTO(calendar);
                    doctorCalendarDTOList.Add(doctorCalendarDTO);

                }
                return doctorCalendarDTOList;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Exception occured while retrieving List of DoctorCalendar Info Ex:{0}", ex.Message);
                return null;
            }

        }
        public DoctorCalendar ConvertTOModel(DoctorCalendarDTO obj)
        {
            
                var doctorCalendar = new DoctorCalendar()
                {
                    DoctorCalendarID = obj.DoctorCalendarID,
                    DoctorID = obj.DoctorID,
                    Date = obj.Date,
                    StartTime = obj.StartTime,
                    EndTime = obj.EndTime

                };
                return doctorCalendar;
            
            
        }

        public DoctorCalendarDTO ConvertTODTO(DoctorCalendar obj)
        {

            var doctorCalendarDTO = new DoctorCalendarDTO()
            {
                DoctorCalendarID = obj.DoctorCalendarID,
                DoctorID = obj.DoctorID,
                Date = obj.Date,
                StartTime = obj.StartTime,
                EndTime = obj.EndTime

            };
            return doctorCalendarDTO;
        }

        
    }
}
