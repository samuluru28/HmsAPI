using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Dto
{
    public class DoctorAppointmentDTO
    {
        //DoctorID,UserID,AppointmentID,UserName,StartTime,EndTime,HospitalName,Date
        public int DoctorID { get; set; }
        public int UserID { get; set; }
        public int AppointmentID { get; set; }
        public string UserName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string HospitalName { get; set; }
        public DateTime Date { get; set; }

    }
}
