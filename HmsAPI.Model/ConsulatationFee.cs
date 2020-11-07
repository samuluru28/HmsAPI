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
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ConsulatationFee fee &&
                   ConsulatationFeeID == fee.ConsulatationFeeID &&
                   DoctorID == fee.DoctorID &&
                   HospitalID == fee.HospitalID &&
                   FeeAmount == fee.FeeAmount &&
                   DoctorAmount == fee.DoctorAmount &&
                   StartTime == fee.StartTime &&
                   EndTime == fee.EndTime;
        }

        public override int GetHashCode()
        {
            int hashCode = -1309917675;
            hashCode = hashCode * -1521134295 + ConsulatationFeeID.GetHashCode();
            hashCode = hashCode * -1521134295 + DoctorID.GetHashCode();
            hashCode = hashCode * -1521134295 + HospitalID.GetHashCode();
            hashCode = hashCode * -1521134295 + FeeAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + DoctorAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + StartTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EndTime.GetHashCode();
            return hashCode;
        }
    }
}
