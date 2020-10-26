using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model.Mapping
{
    public class PatientMedicineMapping:ClassMap<PatientMedicine>
    {
        public PatientMedicineMapping()
        {
            Table("PatientMedicine");
            Id(x => x.PatientMedicineID, "PatientMedicineID");
            Map(x => x.UserID, "UserID").CustomType<int>();           
            Map(x => x.MedicineDescription, "MedicineDescription");
            Map(x => x.AppointmentID, "AppointmentID").CustomType<int>();

        }

    }
}
