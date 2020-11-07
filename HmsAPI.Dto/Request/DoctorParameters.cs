using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Dto.Request
{
    public class DoctorParameters
    {
        public int DoctorID { get; set; }
        public DateTime Docdate { get; set; }
        public int HospitalId { get; set; }
    }
}
