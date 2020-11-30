using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model
{
    public  class PatientMedicine
    {
        public virtual  int PatientMedicineID { get; set; }
        public virtual int UserID { get; set; }
        public virtual string MedicineDescription { get; set; }
        public virtual int AppointmentID { get; set; }

        public override bool Equals(object obj)
        {
            return obj is PatientMedicine medicine &&
                   PatientMedicineID == medicine.PatientMedicineID &&
                   UserID == medicine.UserID &&
                   MedicineDescription == medicine.MedicineDescription &&
                   AppointmentID == medicine.AppointmentID;
        }

        public override int GetHashCode()
        {
            int hashCode = -1443886894;
            hashCode = hashCode * -1521134295 + PatientMedicineID.GetHashCode();
            hashCode = hashCode * -1521134295 + UserID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MedicineDescription);
            hashCode = hashCode * -1521134295 + AppointmentID.GetHashCode();
            return hashCode;
        }
    }
}
