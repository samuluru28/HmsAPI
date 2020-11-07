using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model.Mapping
{
    public class ConsultationFeeMapping : ClassMap<ConsulatationFee>
    {
        public ConsultationFeeMapping()
        {
            Table("ConsultationFee");
            Id(x => x.ConsulatationFeeID, "ConsulatationFeeID");
            Map(x => x.DoctorID, "DoctorID").CustomType<int>();
            Map(x => x.HospitalID, "HospitalID").CustomType<int>();
            Map(x => x.FeeAmount, "FeeAmount");
            Map(x => x.DoctorAmount, "DoctorAmount");
            Map(x => x.StartTime, "StartTime");
            Map(x => x.EndTime, "StartTime");

        }
    }
}
