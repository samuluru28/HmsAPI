using HmsAPI.Dto;
using HmsAPI.Dto.Request;
using HmsAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HmsAPI.Controllers
{
    [RoutePrefix("api/v1/user")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Registers new User Details
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [Route("Register")]
        [HttpPost]       
        public IHttpActionResult Register([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest();
            }

            var results = _userService.Register(userDTO);
            return Ok(results);


        }


        /// <summary>
        /// Checks whether user is validUser or not
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [Route("ValidateUser")]
        [HttpGet]
        public IHttpActionResult ValidateUser([FromUri] LoginParameters parameters)
        {
            if (string.IsNullOrWhiteSpace(parameters.UserName) || string.IsNullOrWhiteSpace(parameters.Password))
                return BadRequest("Invalid UserName or Password");

            var ouserInformationDTO = _userService.ValidateUser(parameters.UserName, parameters.Password);

            if (ouserInformationDTO == null)
            {
                return BadRequest();
            }
            return Ok(ouserInformationDTO);

        }
        

        /// <summary>
        /// Gets the List of All users
        /// </summary>
        /// <returns></returns>
        [Route("GetAllUsers")]
        [HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            var user = _userService.GetAllUsers();
            return Ok(user);

        }


        /// <summary>
        /// Get UserDetails
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [Route("GetUser")]
        [HttpGet]
        public IHttpActionResult GetUserByID(int userID)
        {

            if (userID > 0)
            {
                var oUserDTO = _userService.GetUserByID(userID);
                return Ok(oUserDTO);
            }
            return BadRequest();
        

        }
    }
}
