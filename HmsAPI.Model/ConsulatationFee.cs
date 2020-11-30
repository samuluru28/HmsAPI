using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model
{
    public class ConsulatationFee
    {
        public virtual int ConsulatationFeeID { get; set; }
        public virtual int DoctorID { get; set; }
        public virtual int HospitalID { get; set; }
        public virtual float FeeAmount { get; set; }
        public virtual float DoctorAmount { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ConsulatationFee fee &&
                   ConsulatationFeeID == fee.ConsulatationFeeID &&
                   DoctorID == fee.DoctorID &&
                   HospitalID == fee.HospitalID &&
                   FeeAmount == fee.FeeAmount &&
                   DoctorAmount == fee.DoctorAmount &&
                   StartDate == fee.StartDate &&
                   EndDate == fee.EndDate;
        }

        public override int GetHashCode()
        {
            int hashCode = -1998789331;
            hashCode = hashCode * -1521134295 + ConsulatationFeeID.GetHashCode();
            hashCode = hashCode * -1521134295 + DoctorID.GetHashCode();
            hashCode = hashCode * -1521134295 + HospitalID.GetHashCode();
            hashCode = hashCode * -1521134295 + FeeAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + DoctorAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + StartDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EndDate.GetHashCode();
            return hashCode;
        }
    }
}
