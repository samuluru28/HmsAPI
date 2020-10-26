using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess
{
    public class DoctorCalendarRepository : BaseRepository<DoctorCalendar>, IDoctorCalendarRepository
    {
        public void DeleteDoctorCalendar(int DoctorCalendarID)
        {
            var objDoctorCalendar = GetDoctorCalendarByID(DoctorCalendarID);
            Delete(objDoctorCalendar);
        }

        public DoctorCalendar GetDoctorCalendarByID(int DoctorCalendarID)
        {
            var session = FluentNHibernateHelper.OpenSession();
            var objDoctorCalendar = session.Query<DoctorCalendar>().Where(x => x.DoctorCalendarID == DoctorCalendarID).FirstOrDefault();
            return objDoctorCalendar;
        }
    }
}
