using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess
{
    public class UserTableRepository : BaseRepository<UserTable>, IUserTableRepository
    {
        public void DeleteUser(int UserID)
        {
            var objUser = GetUsersByID(UserID);
            Delete(objUser);   
          
        }

        public UserTable GetUsersByID(int userID)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var objUser = session.Query<UserTable>().Where(x => x.UserID == userID).FirstOrDefault();
                    return objUser;
                }
            }
        }
    }
}
