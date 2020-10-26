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
        public virtual int DoctorCalendarID { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
    }
}
