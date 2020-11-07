using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model
{
    public  class DoctorCalendar
    {
        public virtual int DoctorCalendarID { get; set; }
        public virtual int DoctorID { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual int  HospitalID { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DoctorCalendar calendar &&
                   DoctorCalendarID == calendar.DoctorCalendarID &&
                   DoctorID == calendar.DoctorID &&
                   Date == calendar.Date &&
                   StartTime == calendar.StartTime &&
                   EndTime == calendar.EndTime &&
                   HospitalID == calendar.HospitalID;
        }

        public override int GetHashCode()
        {
            int hashCode = 292862208;
            hashCode = hashCode * -1521134295 + DoctorCalendarID.GetHashCode();
            hashCode = hashCode * -1521134295 + DoctorID.GetHashCode();
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + StartTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EndTime.GetHashCode();
            hashCode = hashCode * -1521134295 + HospitalID.GetHashCode();
            return hashCode;
        }
    }
}
