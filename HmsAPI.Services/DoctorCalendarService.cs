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
    public class DoctorCalendarService: IDoctorCalendarService
    {
        public readonly IDoctorCalendarRepository _doctorCalendarRepository;
        public DoctorCalendarService(IDoctorCalendarRepository doctorCalendarRepository)
        {
            _doctorCalendarRepository = doctorCalendarRepository;
        }

        public DoctorCalendarDTO AddDoctorCalender(DoctorCalendarDTO obj)
        {
            var objDoctorCalendar = ConvertTOModel(obj);
            var results = _doctorCalendarRepository.SaveorUpdate(objDoctorCalendar);
            return ConvertTODTO(results);

        }

        public DoctorCalendarDTO GetDoctorCalendarByID(int doctorCalendarID)
        {
            var doctorCalendar = _doctorCalendarRepository.GetDoctorCalendarByID(doctorCalendarID);

            return ConvertTODTO(doctorCalendar);
        }

        public IEnumerable<DoctorCalendarDTO> GetAllDoctorsCalendar()
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
        public DoctorCalendar ConvertTOModel(DoctorCalendarDTO obj)
        {

            var doctorCalendar = new DoctorCalendar()
            {
                DoctorCalendarID = obj.DoctorCalendarID,
                DoctorID = obj.DoctorID,
                Date= obj.Date,
                StartTime= obj.StartTime,
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
