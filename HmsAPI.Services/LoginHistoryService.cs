using HmsAPI.Dto;
using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services
{
    public class LoginHistoryService
    {
        public LoginHistory ConvertTOModel(LoginHistoryDTO obj)
        {

            var loginHistory = new LoginHistory()
            {
                LoginHistoryID = obj.LoginHistoryID,
                StartTime = obj.StartTime,
                EndTime = obj.EndTime,
                UserID = obj.UserID

            };
            return loginHistory;
        }

        public LoginHistoryDTO ConvertTODTO(LoginHistory obj)
        {

            var loginHistoryDTO = new LoginHistoryDTO()
            {
                LoginHistoryID = obj.LoginHistoryID,
                StartTime = obj.StartTime,
                EndTime = obj.EndTime,
                UserID = obj.UserID


            };
            return loginHistoryDTO;
        }
    }
}
