using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Dto
{
    public class DoctorDTO
    {
        public int DoctorID { get; set; }
        public string LicenseNumber { get; set; }
        public string Specialist { get; set; }
        public char Active { get; set; }
        public int VerifiedBy { get; set; }
        public int UserID { get; set; }
    }
}
