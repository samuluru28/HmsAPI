using HmsAPI.DataAccess;
using HmsAPI.Dto;
using HmsAPI.Model;
using HmsAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using log4net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services
{
    public class RolesService : IRoleService
    {
        private ILog log = LogManager.GetLogger(typeof(RolesService));

        public readonly IRolesRepository _roleRepository;
        public RolesService(IRolesRepository rolesRepository)
        {
            _roleRepository = rolesRepository;

        }

        public RolesDTO AddRoles(RolesDTO obj)
        {
            try
            {
                var objRole = ConvertTOModel(obj);
                var role = _roleRepository.SaveorUpdate(objRole);
                log.Info("Role Added Successfully");
                return ConvertTODTO(role);
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Exception occured while Adding new Role Ex:{0}", ex.Message);
                return null;

            }
        }

        public RolesDTO GetRolesByID(int roleID)
        {
            try
            {
                var role = _roleRepository.GetRolesByID(roleID);
                return ConvertTODTO(role);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Exception occured while retrieving Role details Ex:{0}", ex.Message);
                return null;

            }

        }

        public List<RolesDTO> GetAllRoles()
        {
            try
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
            catch (Exception ex)
            {
                log.ErrorFormat("Exception occured while retrieving all the list of Role details Ex:{0}", ex.Message);
                return null;

            }
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
