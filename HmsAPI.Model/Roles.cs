using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model
{
    public class Roles
    {
        public  int RoleID { get; set; }
        public  string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Roles roles &&
                   RoleID == roles.RoleID &&
                   Name == roles.Name;
        }

        public override int GetHashCode()
        {
            int hashCode = -1773594654;
            hashCode = hashCode * -1521134295 + RoleID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
