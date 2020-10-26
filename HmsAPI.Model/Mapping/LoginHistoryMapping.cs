using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model.Mapping
{
    public class LoginHistoryMapping: ClassMap<LoginHistory>
    {
        public LoginHistoryMapping()
        {
            Table("LoginHistory");           
            Id(x => x.LoginHistoryID, "LoginHistoryID");
            Map(x => x.UserID, "UserID").CustomType<int>();
            Map(x => x.StartTime, "StartTime");
            Map(x => x.EndTime, "EndTime");
        }
    }
}
