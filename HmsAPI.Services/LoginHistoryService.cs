using HmsAPI.DataAccess;
using HmsAPI.Dto;
using HmsAPI.Model;
using HmsAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services
{
    public class LoginHistoryService: ILoginHistoryService
    {
        public readonly ILoginHistoryRepository _loginHistoryRepository;
        public LoginHistoryService(ILoginHistoryRepository loginHistoryRepository)
        {
            _loginHistoryRepository = loginHistoryRepository;

        }

        public LoginHistoryDTO AddLoginHistory(LoginHistoryDTO obj)
        {
            var objHistory = ConvertTOModel(obj);
            var loginHistory = _loginHistoryRepository.SaveorUpdate(objHistory);
            return ConvertTODTO(loginHistory);
        }

        public LoginHistoryDTO GetLoginHistoryByID(int loginHistoryID)
        {
            var loginHistory = _loginHistoryRepository.GetLoginHistoryByID(loginHistoryID);
            return ConvertTODTO(loginHistory);
        }

        public IEnumerable<LoginHistoryDTO> GetAllHistory()
        {
            List<LoginHistoryDTO> loginHistoryDTOList = new List<LoginHistoryDTO>();
            IEnumerable<LoginHistory> loginHistoryDTO = _loginHistoryRepository.GetAll();
            foreach (var history in loginHistoryDTO)
            {
                var historyDTO = ConvertTODTO(history);
                loginHistoryDTOList.Add(historyDTO);

            }
            return loginHistoryDTOList;
        }
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
