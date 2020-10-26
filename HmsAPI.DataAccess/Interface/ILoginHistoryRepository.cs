using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess
{
    public interface ILoginHistoryRepository
    {
        LoginHistory SaveorUpdate(LoginHistory obj);
        IEnumerable<LoginHistory> GetAll();

        LoginHistory GetLoginHistoryByID(int LoginHistoryID);

        void DeleteLoginHsitory(int LoginHistoryID);
    }
}
