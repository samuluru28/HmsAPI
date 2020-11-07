using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model
{
    public class Hospital
    {
        public  int HospitalID { get; set; }
        public  string Name { get; set; }
        public  string PhoneNumber { get; set; }
        public  string EmailID { get; set; }

        public  string Address { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Hospital hospital &&
                   HospitalID == hospital.HospitalID &&
                   Name == hospital.Name &&
                   PhoneNumber == hospital.PhoneNumber &&
                   EmailID == hospital.EmailID &&
                   Address == hospital.Address;
        }

        public override int GetHashCode()
        {
            int hashCode = 197011055;
            hashCode = hashCode * -1521134295 + HospitalID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PhoneNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EmailID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            return hashCode;
        }
    }
}
