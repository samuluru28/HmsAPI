using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model.Mapping
{
    public class UserRolesMapping : ClassMap<UserRoles>
    {
        public UserRolesMapping()
        {
            Table("UserRoles");
            Id(x => x.UserRoleID, "UserRoleID");
            Map(x => x.UserID, "UserID").CustomType<int>();
            Map(x => x.RoleID, "RoleID").CustomType<int>();
            Map(x => x.HospitalID, "HospitalID").CustomType<int>();
        }
    }
}
