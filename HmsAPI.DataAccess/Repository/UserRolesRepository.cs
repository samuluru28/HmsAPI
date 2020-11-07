using HmsAPI.DataAccess.Interface;
using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess.Repository
{
    public class UserRolesRepository:BaseRepository<UserRoles>,IUserRoleRepository
    {
        public void DeleteUserRole(int userRoleID)
        {
            var objuserRole = GetUserRolesByID(userRoleID);
            Delete(objuserRole);

        }

        public UserRoles GetUserRolesByID(int userRoleID)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var objUserRole = session.Query<UserRoles>().Where(x => x.UserRoleID == userRoleID).FirstOrDefault();
                    return objUserRole;
                }
            }
        }
        public UserRoles GetUserRolesByuserID(int userID)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var objUserRole = session.Query<UserRoles>().Where(x => x.UserID == userID).FirstOrDefault();
                    return objUserRole;
                }
            }
        }
    }
}
