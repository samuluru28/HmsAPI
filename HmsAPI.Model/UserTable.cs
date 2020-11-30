using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model
{
    public  class User
    {
        public virtual  int UserID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime DOB { get; set; }
        public virtual char Gender { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }

        public virtual string EmailID { get; set; }

        public virtual string PhoneNumber { get; set; }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   UserID == user.UserID &&
                   FirstName == user.FirstName &&
                   LastName == user.LastName &&
                   DOB == user.DOB &&
                   Gender == user.Gender &&
                   UserName == user.UserName &&
                   Password == user.Password &&
                   EmailID == user.EmailID &&
                   PhoneNumber == user.PhoneNumber;
        }

        public override int GetHashCode()
        {
            int hashCode = 954011070;
            hashCode = hashCode * -1521134295 + UserID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + DOB.GetHashCode();
            hashCode = hashCode * -1521134295 + Gender.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EmailID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PhoneNumber);
            return hashCode;
        }
    }
}
