using HmsAPI.Dto;
using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services
{
    public class RolesService
    {
        public Roles ConvertTOModel(RolesDTO obj)
        {

            var roles = new Roles()
            {
                RoleID = obj.RoleID,
                Name = obj.Name               

            };
            return roles;
        }

        public RolesDTO ConvertTODTO(Roles obj)
        {

            var rolesDTO = new RolesDTO()
            {
                RoleID = obj.RoleID,
                Name = obj.Name

            };
            return rolesDTO;
        }
    }
}
