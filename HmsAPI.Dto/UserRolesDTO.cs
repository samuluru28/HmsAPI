using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Dto
{
    public class UserRolesDTO
    {
        public int UserRoleID { get; set; }
        public int RoleID { get; set; }
        public int UserID { get; set; }
        public int HospitalID { get; set; }
    }
}
