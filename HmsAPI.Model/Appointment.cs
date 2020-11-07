using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model
{
    public  class Appointment
    {
        public virtual int AppointmentID { get; set; }
        public virtual int UserID { get; set; }
        public virtual int DoctorID { get; set; }
        public virtual DateTime AppDate { get; set; }
        public virtual int DoctorCalendarID { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Appointment appointment &&
                   AppointmentID == appointment.AppointmentID &&
                   UserID == appointment.UserID &&
                   DoctorID == appointment.DoctorID &&
                   AppDate == appointment.AppDate &&
                   DoctorCalendarID == appointment.DoctorCalendarID &&
                   StartTime == appointment.StartTime &&
                   EndTime == appointment.EndTime;
        }

        public override int GetHashCode()
        {
            int hashCode = 1832843767;
            hashCode = hashCode * -1521134295 + AppointmentID.GetHashCode();
            hashCode = hashCode * -1521134295 + UserID.GetHashCode();
            hashCode = hashCode * -1521134295 + DoctorID.GetHashCode();
            hashCode = hashCode * -1521134295 + AppDate.GetHashCode();
            hashCode = hashCode * -1521134295 + DoctorCalendarID.GetHashCode();
            hashCode = hashCode * -1521134295 + StartTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EndTime.GetHashCode();
            return hashCode;
        }
    }
}
