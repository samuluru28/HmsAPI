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
        UserDTO Register(UserDTO obj);
        UserInformationDTO ValidateUser(string userName, string password);

        UserDTO GetUserByID(int userID);

        List<UserDTO> GetAllUsers();
       
        
    }
}
