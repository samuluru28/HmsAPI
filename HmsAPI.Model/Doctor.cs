using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model
{
    public  class Doctor
    {
        public virtual int DoctorID { get; set; }
        public virtual string LicenseNumber { get; set; }
        public virtual string Specialist { get; set; }
        public virtual char Active { get; set; }
        public virtual int VerifiedBy { get; set; }
        public virtual int UserID { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Doctor doctor &&
                   DoctorID == doctor.DoctorID &&
                   LicenseNumber == doctor.LicenseNumber &&
                   Specialist == doctor.Specialist &&
                   Active == doctor.Active &&
                   VerifiedBy == doctor.VerifiedBy &&
                   UserID == doctor.UserID;
        }

        public override int GetHashCode()
        {
            int hashCode = 57109602;
            hashCode = hashCode * -1521134295 + DoctorID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LicenseNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Specialist);
            hashCode = hashCode * -1521134295 + Active.GetHashCode();
            hashCode = hashCode * -1521134295 + VerifiedBy.GetHashCode();
            hashCode = hashCode * -1521134295 + UserID.GetHashCode();
            return hashCode;
        }
    }
}
