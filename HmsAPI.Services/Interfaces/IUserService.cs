using HmsAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services.Interfaces
{
    public interface IUserService
    {
        UserTableDTO Register(UserTableDTO obj);
        UserInformationDTO ValidateUser(string userName, string password);

        UserTableDTO GetUserByID(int userID);

        IEnumerable<UserTableDTO> GetAllUsers();
       
        
    }
}
