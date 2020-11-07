using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model.Mapping
{
    public class AppointmentMapping : ClassMap<Appointment>
    {
        public AppointmentMapping()
        {
            Table("Appointment");
            Id(x => x.AppointmentID, "AppointmentID");
            Map(x => x.UserID, "UserID").CustomType<int>();
            Map(x => x.DoctorCalendarID, "DoctorCalendarID").CustomType<int>();
            Map(x => x.DoctorID, "DoctorID").CustomType<int>();
            Map(x => x.AppDate, "AppDate");
            Map(x => x.StartTime, "StartTime");
            Map(x => x.EndTime, "EndTime");
        }


    }
}
