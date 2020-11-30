using HmsAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services.Interfaces
{
    public interface IRolesService
    {
        RolesDTO AddRoles(RolesDTO obj);

        RolesDTO GetRolesByID(int roleID);

        List<RolesDTO> GetAllRoles();

    }
}
