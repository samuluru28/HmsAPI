using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Dto
{
    public class HospitalDTO
    {
        public  int HospitalID { get; set; }
        public  string Name { get; set; }
        public  string PhoneNumber { get; set; }
        public  string EmailID { get; set; }

        public  string Address { get; set; }

    }
}
