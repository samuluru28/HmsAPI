using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model.Mapping
{
    public class UserTableMapping: ClassMap<User>
    {
        public UserTableMapping()
        {
            Table("UserTable");
            Id(x => x.UserID, "UserID");
            Map(x => x.FirstName, "FirstName");
            Map(x => x.LastName, "LastName");
            Map(x => x.DOB, "DOB");
            Map(x => x.Gender, "Gender");
            Map(x => x.UserName, "UserName");
            Map(x => x.EmailID, "EmailID");
            Map(x => x.Password, "Password");
            Map(x => x.PhoneNumber, "PhoneNumber");           
        }
    }
}

