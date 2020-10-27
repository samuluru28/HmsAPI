using HmsAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services.Interfaces
{
    public interface ILoginHistoryService
    {
        LoginHistoryDTO AddLoginHistory(LoginHistoryDTO obj);

        LoginHistoryDTO GetLoginHistoryByID(int loginHistoryID);

        IEnumerable<LoginHistoryDTO> GetAllHistory();
    }
}
