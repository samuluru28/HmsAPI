using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model
{
    public  class PatientMedicine
    {
        public virtual int PatientMedicineID { get; set; }
        public virtual int UserID { get; set; }
        public virtual string MedicineDescription { get; set; }
        public virtual int AppointmentID { get; set; }
    }
}
