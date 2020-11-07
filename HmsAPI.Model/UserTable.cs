using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model
{
    public  class User
    {
        public   int UserID { get; set; }
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  DateTime DOB { get; set; }
        public  char Gender { get; set; }
        public  string UserName { get; set; }
        public  string Password { get; set; }

        public  string EmailID { get; set; }

        public  string PhoneNumber { get; set; }
        

        public override bool Equals(object obj)
        {
            return obj is User table &&
                   UserID == table.UserID &&
                   FirstName == table.FirstName &&
                   LastName == table.LastName &&
                   DOB == table.DOB &&
                   Gender == table.Gender &&
                   UserName == table.UserName &&
                   Password == table.Password &&
                   EmailID == table.EmailID &&
                   PhoneNumber == table.PhoneNumber;
        }

        public override int GetHashCode()
        {
            int hashCode = -1006295318;
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
