using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Model
{
    public  class LoginHistory
    {
        public virtual int LoginHistoryID { get; set; }
        public virtual int UserID { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }

        public override bool Equals(object obj)
        {
            return obj is LoginHistory history &&
                   LoginHistoryID == history.LoginHistoryID &&
                   UserID == history.UserID &&
                   StartTime == history.StartTime &&
                   EndTime == history.EndTime;
        }

        public override int GetHashCode()
        {
            int hashCode = 816852927;
            hashCode = hashCode * -1521134295 + LoginHistoryID.GetHashCode();
            hashCode = hashCode * -1521134295 + UserID.GetHashCode();
            hashCode = hashCode * -1521134295 + StartTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EndTime.GetHashCode();
            return hashCode;
        }
    }
}
