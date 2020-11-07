using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model
{
    public class UserRoles
    {
        public virtual int UserRoleID { get; set; }
        public virtual int RoleID { get; set; }
        public virtual int UserID { get; set; }
        public virtual int HospitalID { get; set; }

        public override bool Equals(object obj)
        {
            return obj is UserRoles roles &&
                   UserRoleID == roles.UserRoleID &&
                   RoleID == roles.RoleID &&
                   UserID == roles.UserID &&
                   HospitalID == roles.HospitalID;
        }

        public override int GetHashCode()
        {
            int hashCode = -1482740488;
            hashCode = hashCode * -1521134295 + UserRoleID.GetHashCode();
            hashCode = hashCode * -1521134295 + RoleID.GetHashCode();
            hashCode = hashCode * -1521134295 + UserID.GetHashCode();
            hashCode = hashCode * -1521134295 + HospitalID.GetHashCode();
            return hashCode;
        }
    }
}
