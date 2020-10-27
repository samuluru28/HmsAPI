using HmsAPI.Dto;
using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services
{
    public class DoctorCalendarService
    {
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
