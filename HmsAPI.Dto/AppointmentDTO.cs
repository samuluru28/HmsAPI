using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Dto
{
    public class AppointmentDTO
    {
        public int AppointmentID { get; set; }
        public int UserID { get; set; }
        public int DoctorID { get; set; }
        public int DoctorCalendarID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
