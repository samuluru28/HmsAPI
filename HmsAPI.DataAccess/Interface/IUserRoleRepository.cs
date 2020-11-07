using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess.Interface
{
    public interface IUserRoleRepository
    {
        UserRoles SaveorUpdate(UserRoles obj);
        IEnumerable<UserRoles> GetAll();
        void DeleteUserRole(int userRoleID);
        UserRoles GetUserRolesByID(int userRoleID);
        UserRoles GetUserRolesByuserID(int userID);
    }
}
