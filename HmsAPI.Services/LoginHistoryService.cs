using HmsAPI.DataAccess;
using HmsAPI.Dto;
using HmsAPI.Model;
using HmsAPI.Services.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services
{
    public class LoginHistoryService: ILoginHistoryService
    {
        private ILog log = LogManager.GetLogger(typeof(LoginHistoryService));
        public readonly ILoginHistoryRepository _loginHistoryRepository;
        public LoginHistoryService(ILoginHistoryRepository loginHistoryRepository)
        {
            _loginHistoryRepository = loginHistoryRepository;

        }

        public LoginHistoryDTO AddLoginHistory(LoginHistoryDTO obj)
        {
            try
            {
                var objHistory = ConvertTOModel(obj);
                var loginHistory = _loginHistoryRepository.SaveorUpdate(objHistory);
                log.Info("LoginHistory saved Successfully");
                return ConvertTODTO(loginHistory);
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Exception occured while adding LoginHistory Information Ex:{0}", ex.Message);
                return null;

            }
        }

        public LoginHistoryDTO GetLoginHistoryByID(int loginHistoryID)
        {
            try
            {
                var loginHistory = _loginHistoryRepository.GetLoginHistoryByID(loginHistoryID);
                return ConvertTODTO(loginHistory);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Exception occured while retreiving LoginHistory Information Ex:{0}", ex.Message);
                return null;

            }
        }

        public List<LoginHistoryDTO> GetAllHistory()
        {
            try
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
            catch(Exception ex)
            {
                log.ErrorFormat("Exception occured while retreiving all the List of LoginHistory Information Ex:{0}", ex.Message);
                return null;

            }
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
