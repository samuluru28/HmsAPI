using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess
{
    public class LoginHistoryRepository : BaseRepository<LoginHistory>, ILoginHistoryRepository
    {
      
        public LoginHistory GetLoginHistoryByID(int loginHistoryID)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var objloginHistory = session.Query<LoginHistory>().Where(x => x.LoginHistoryID == loginHistoryID).FirstOrDefault();
                    return objloginHistory;
                }
            }
        }
        public void DeleteLoginHsitory(int LoginHistoryID)
        {
            var objLoginHistory = GetLoginHistoryByID(LoginHistoryID);
            Delete(objLoginHistory);
        }
    }
}
