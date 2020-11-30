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
    [RoutePrefix("api/v1/role")]
    public class RoleController: ApiController
    {
        private readonly IRolesService _roleService;
        public RoleController(IRolesService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Adds a new Role Information
        /// </summary>
        /// <param name="roleDTO"></param>
        /// <returns></returns>
        [Route("AddRole")]
        [HttpPost]       
        public IHttpActionResult AddRoles([FromBody] RolesDTO roleDTO)
        {
            if (roleDTO == null)
            {
                return BadRequest();
            }

            var results = _roleService.AddRoles(roleDTO);
            return Ok(results);


        }


        /// <summary>
        /// Get The Role Info
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        [Route("GetRole")]
        [HttpGet]
        public IHttpActionResult GetRoleByID(int roleID)
        {
            if (roleID > 0)
            {
                var oRoleDTO = _roleService.GetRolesByID(roleID);
                return Ok(oRoleDTO);
            }
            return BadRequest();

        }

        
    }
}
