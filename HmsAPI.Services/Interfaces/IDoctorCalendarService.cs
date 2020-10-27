using HmsAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services.Interfaces
{
    public interface IDoctorCalendarService
    {
        DoctorCalendarDTO AddDoctorCalender(DoctorCalendarDTO obj);

        DoctorCalendarDTO GetDoctorCalendarByID(int doctorCalendarID);

        IEnumerable<DoctorCalendarDTO> GetAllDoctorsCalendar();
    }
}
