using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess
{
    public interface IRolesRepository
    {
        Roles SaveorUpdate(Roles obj);
        IEnumerable<Roles> GetAll();

        Roles GetRolesByID(int RoleID);

        void DeleteRole(int RoleID);
    }
}
