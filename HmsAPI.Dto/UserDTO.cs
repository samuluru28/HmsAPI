using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Dto
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public char Gender { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string EmailID { get; set; }

        public string PhoneNumber { get; set; }       
    }
}
