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

        public UserTable GetUsersByID(int UserID)
        {
            var session = FluentNHibernateHelper.OpenSession();
            var objUser = session.Query<UserTable>().Where(x => x.UserID == UserID).FirstOrDefault();
            return objUser;

        }
    }
}
