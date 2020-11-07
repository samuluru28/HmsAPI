using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess
{
    public interface IDoctorCalendarRepository
    {
        DoctorCalendar SaveorUpdate(DoctorCalendar obj);
        IEnumerable<DoctorCalendar> GetAll();

        DoctorCalendar GetDoctorCalendarByID(int DoctorCalendarID);

        void DeleteDoctorCalendar(int DoctorCalendarID);
        List<DoctorCalendar> GetDoctorCalendar(int doctorID, DateTime date, int hospitalID);

    }
}
