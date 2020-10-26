using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess
{
    public class RolesRepository: BaseRepository<Roles>,IRolesRepository
    {
        public void DeleteRole(int RoleID)
        {
            var objRole = GetRolesByID(RoleID);
            Delete(objRole);

        }

        public Roles GetRolesByID(int roleID)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var objRole = session.Query<Roles>().Where(x => x.RoleID == roleID).FirstOrDefault();
                    return objRole;
                }
            }
        }
    }
}
