using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model
{
    public  class PatientMedicine
    {
        public  int PatientMedicineID { get; set; }
        public  int UserID { get; set; }
        public  string MedicineDescription { get; set; }
        public  int AppointmentID { get; set; }
    }
}
