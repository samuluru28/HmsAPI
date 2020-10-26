using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model
{
    public  class UserTable
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
        public virtual int RoleID { get; set; }

        public override bool Equals(object obj)
        {
            return obj is UserTable table &&
                   UserID == table.UserID &&
                   FirstName == table.FirstName &&
                   LastName == table.LastName &&
                   DOB == table.DOB &&
                   Gender == table.Gender &&
                   UserName == table.UserName &&
                   Password == table.Password &&
                   EmailID == table.EmailID &&
                   PhoneNumber == table.PhoneNumber &&
                   RoleID == table.RoleID;
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
            hashCode = hashCode * -1521134295 + RoleID.GetHashCode();
            return hashCode;
        }
    }
}
