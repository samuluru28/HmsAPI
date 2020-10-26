using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model.Mapping
{
    public class RolesMapping: ClassMap<Roles>
    {
        public RolesMapping()
        {
            Table("Roles");
            Id(x => x.RoleID, "RoleID");
            Map(x => x.Name, "Name");
        }
    }
}
