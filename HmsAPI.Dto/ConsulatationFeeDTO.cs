using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Dto
{
    public class ConsulatationFeeDTO
    {
        public  int ConsulatationFeeID { get; set; }
        public  int DoctorID { get; set; }
        public  int HospitalID { get; set; }
        public  float FeeAmount { get; set; }
        public  float DoctorAmount { get; set; }
        public  DateTime StartTime { get; set; }
        public  DateTime EndTime { get; set; }

    }
}
