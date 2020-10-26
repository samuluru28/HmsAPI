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
        public void DeleteLoginHsitory(int LoginHistoryID)
        {
            var objLoginHistory = GetLoginHistoryByID(LoginHistoryID);
            Delete(objLoginHistory);
        }

        public LoginHistory GetLoginHistoryByID(int LoginHistoryID)
        {
            var session = FluentNHibernateHelper.OpenSession();
            var objLoginHistory = session.Query<LoginHistory>().Where(x => x.LoginHistoryID == LoginHistoryID).FirstOrDefault();
            return objLoginHistory;
        }
    }
}
