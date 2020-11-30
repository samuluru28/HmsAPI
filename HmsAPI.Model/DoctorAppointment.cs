using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model
{
    public class DoctorAppointment
    {
        public virtual int DoctorID { get; set; }
        public virtual int UserID { get; set; }
        public virtual int AppointmentID { get; set; }
        public virtual string UserName { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual string HospitalName { get; set; }
        public virtual DateTime Date { get; set; }

        public override bool Equals(object obj)
        {
            return obj is DoctorAppointment appointment &&
                   DoctorID == appointment.DoctorID &&
                   UserID == appointment.UserID &&
                   AppointmentID == appointment.AppointmentID &&
                   UserName == appointment.UserName &&
                   StartTime == appointment.StartTime &&
                   EndTime == appointment.EndTime &&
                   HospitalName == appointment.HospitalName &&
                   Date == appointment.Date;
        }

        public override int GetHashCode()
        {
            int hashCode = 1968497320;
            hashCode = hashCode * -1521134295 + DoctorID.GetHashCode();
            hashCode = hashCode * -1521134295 + UserID.GetHashCode();
            hashCode = hashCode * -1521134295 + AppointmentID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserName);
            hashCode = hashCode * -1521134295 + StartTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EndTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(HospitalName);
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            return hashCode;
        }
    }
}
