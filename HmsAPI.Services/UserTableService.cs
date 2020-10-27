using HmsAPI.Dto;
using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services
{
    public class UserTableService
    {
        public UserTable ConvertTOModel(UserTableDTO obj)
        {

            var User = new UserTable()
            {
                UserID = obj.UserID,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                DOB = obj.DOB,
                Gender = obj.Gender,
                UserName = obj.UserName,
                EmailID = obj.EmailID,
                PhoneNumber = obj.PhoneNumber,
                RoleID= obj.RoleID,

            };
            return User;
        }

        public UserTableDTO ConvertTODTO(UserTable obj)
        {

            var UserDTO = new UserTableDTO()
            {
                UserID = obj.UserID,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                DOB = obj.DOB,
                Gender = obj.Gender,
                UserName = obj.UserName,
                EmailID = obj.EmailID,
                PhoneNumber = obj.PhoneNumber,
                RoleID = obj.RoleID,

            };
            return UserDTO;
        }
    }
}
