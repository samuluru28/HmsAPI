using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model.Mapping
{
    public class DoctorMapping : ClassMap<Doctor>
    {
        public DoctorMapping()
        {
            Table("Doctor");
            Id(x => x.DoctorID, "DoctorID");
            Map(x => x.LicenseNumber, "LicenseNumber");
            Map(x => x.Specialist, "Specialist");
            Map(x => x.Active, "Active");
            Map(x => x.VerifiedBy, "VerifiedBy").CustomType<int>();
            Map(x => x.UserID, "UserID").CustomType<int>();
            
        }

    }
}
