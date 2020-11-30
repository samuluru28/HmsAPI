using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model.Mapping
{
    public class DoctorCalendarMapping: ClassMap<DoctorCalendar>
    {
        public DoctorCalendarMapping()
        {
            Table("DoctorCalendar");
            Id(x => x.DoctorCalendarID, "DoctorCalendarID");
            Map(x => x.DoctorID, "DoctorID").CustomType<int>();
            Map(x => x.Date, "Date");
            Map(x => x.StartTime, "StartTime");
            Map(x => x.EndTime, "EndTime");
            Map(x => x.HospitalID, "HospitalID");
        }
    }
}
