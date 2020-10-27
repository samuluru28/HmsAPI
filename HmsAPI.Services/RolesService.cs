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
    public class RolesService : IRoleService
    {
        public readonly IRolesRepository _roleRepository;
        public RolesService(IRolesRepository rolesRepository)
        {
            _roleRepository = rolesRepository;

        }

        public RolesDTO AddRoles(RolesDTO obj)
        {
            var objRole = ConvertTOModel(obj);
            var role = _roleRepository.SaveorUpdate(objRole);
            return ConvertTODTO(role);
        }

        public RolesDTO GetRolesByID(int roleID)
        {
            var role = _roleRepository.GetRolesByID(roleID);

            return ConvertTODTO(role);
        }

        public IEnumerable<RolesDTO> GetAllRoles()
        {
            List<RolesDTO> rolesDTOList = new List<RolesDTO>();
            IEnumerable<Roles> roles = _roleRepository.GetAll();
            foreach (var role in roles)
            {
                var roleDTO = ConvertTODTO(role);
                rolesDTOList.Add(roleDTO);

            }
            return rolesDTOList;
        }
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
