using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Dto
{
    public class UserAppointmentDTO
    {
        public int AppointmentID { get; set; }
        public int UserID { get; set; }
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string HospitalName { get; set; }

    }
}
