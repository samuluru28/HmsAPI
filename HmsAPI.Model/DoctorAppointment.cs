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

    }
}
