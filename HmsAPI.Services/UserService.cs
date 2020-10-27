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
    public class UserService: IUserService
    {
        public readonly IUserTableRepository _userTableRepository;
        public UserService(IUserTableRepository userTableRepository)
        {
            _userTableRepository = userTableRepository;

        }

        public UserTableDTO Register(UserTableDTO obj)
        {
            var objUser = ConvertTOModel(obj);
            var results = _userTableRepository.SaveorUpdate(objUser);
            return ConvertTODTO(results);

        }

        public UserInformationDTO ValidateUser(string userName, string password)
        {
            var results = _userTableRepository.ValidateUser(userName, password);
            if(results!=null)
            {
                var userInformation = new UserInformationDTO
                {
                    UserID = results.UserID,
                    RoleID = results.RoleID,
                    Name = results.FirstName + " " + results.LastName
                };
                return userInformation;
            }
            return null;
        }

        public UserTableDTO GetUserByID(int userID)
        {
            var user = _userTableRepository.GetUsersByID(userID);

            return ConvertTODTO(user);
            
        }

        public IEnumerable<UserTableDTO> GetAllUsers()
        {
            List<UserTableDTO> userTableDTOList = new List<UserTableDTO>();
            IEnumerable<UserTable> user = _userTableRepository.GetAll();
            foreach(var item in user)
            {
               var userDTO = ConvertTODTO(item);
                userTableDTOList.Add(userDTO);

            }
            return userTableDTOList;
        }
        private UserTable ConvertTOModel(UserTableDTO obj)
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

        private UserTableDTO ConvertTODTO(UserTable obj)
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
