using HmsAPI.Dto;
using HmsAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HmsAPI.Controllers
{
    [RoutePrefix("api/v1/loginhistory")]
    public class LoginHistoryController: ApiController
    {
        
        private readonly ILoginHistoryService _loginHistoryService;
        public LoginHistoryController(ILoginHistoryService loginHistoryService)
        {
            _loginHistoryService = loginHistoryService;
        }


        /// <summary>
        /// Adds LoginHistory Info
        /// </summary>
        /// <param name="loginHistoryDTO"></param>
        /// <returns></returns>
        [Route("AddLoginHistory")]
        [HttpPost]
        public IHttpActionResult AddLoginHistory([FromBody] LoginHistoryDTO loginHistoryDTO)
        {
            if (loginHistoryDTO == null)
            {
                return BadRequest();
            }

            var results = _loginHistoryService.AddLoginHistory(loginHistoryDTO);
            return Ok(results);
        }



        /// <summary>
        /// Get LoginHistory Details
        /// </summary>
        /// <param name="loginHistoryID"></param>
        /// <returns></returns>
        [Route("GetLoginHistory")]
        [HttpGet]
        public IHttpActionResult GetLoginHistoryByID(int loginHistoryID)
        {
            var oLoginHistoryDTO = _loginHistoryService.GetLoginHistoryByID(loginHistoryID);
            return Ok(oLoginHistoryDTO);

        }

        /// <summary>
        /// Gets List of LoginHistory Details
        /// </summary>
        /// <returns></returns>
        [Route("GetAllLoginHistory")]
        [HttpGet]
        public IHttpActionResult GetAllLoginHistory()
        {
            var oLoginHistoryDTO = _loginHistoryService.GetAllHistory();
            return Ok(oLoginHistoryDTO.ToList());

        }

    }

}
