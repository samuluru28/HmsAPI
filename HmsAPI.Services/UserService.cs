using HmsAPI.DataAccess;
using HmsAPI.DataAccess.Interface;
using HmsAPI.Dto;
using HmsAPI.Model;
using HmsAPI.Services.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services
{
    public class UserService: IUserService
    {
        private ILog log = LogManager.GetLogger(typeof(UserService));
        public readonly IUserRepository _userTableRepository;
        public readonly IUserRoleRepository _userRoleRepository;

        public UserService(IUserRepository userTableRepository,IUserRoleRepository userRoleRepository)
        {
            _userTableRepository = userTableRepository;
            _userRoleRepository = userRoleRepository;

        }

        public UserDTO Register(UserDTO obj)
        {
            try
            {
                var objUser = ConvertTOModel(obj);
                var results = _userTableRepository.SaveorUpdate(objUser);
                log.Info("User Added/Modified Successfully");
                return ConvertTODTO(results);
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Exception occured while Registering new User Ex:{0}", ex.Message);
                return null;
            }

        }

        public UserInformationDTO ValidateUser(string userName, string password)
        {
            try
            {
                var results = _userTableRepository.ValidateUser(userName, password);
                if (results != null)
                {
                    var objUserRole = _userRoleRepository.GetUserRolesByuserID(results.UserID);
                    var userInformation = new UserInformationDTO
                    {
                        UserID = results.UserID,
                        RoleID = objUserRole.RoleID,
                        Name = results.FirstName + " " + results.LastName
                    };
                    log.Info("User Validated Successfully");
                    return userInformation;
                }
                return null;
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Exception occured while Validating the User Ex:{0}", ex.Message);
                return null;
            }
        }

        public UserDTO GetUserByID(int userID)
        {
            try
            {
                var user = _userTableRepository.GetUsersByID(userID);

                return ConvertTODTO(user);
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Exception occured while retreiving User Details Ex:{0}", ex.Message);
                return null;

            }
            
        }

        public List<UserDTO> GetAllUsers()
        {
            try
            {
                List<UserDTO> userTableDTOList = new List<UserDTO>();
                IEnumerable<User> user = _userTableRepository.GetAll();
                foreach (var item in user)
                {
                    var userDTO = ConvertTODTO(item);
                    userTableDTOList.Add(userDTO);

                }
                return userTableDTOList;
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Exception occured while retreiving List of all Users Ex:{0}", ex.Message);
                return null;
            }
        }
        private User ConvertTOModel(UserDTO obj)
        {

            var User = new User()
            {
                UserID = obj.UserID,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                DOB = obj.DOB,
                Gender = obj.Gender,
                UserName = obj.UserName,
                EmailID = obj.EmailID,
                PhoneNumber = obj.PhoneNumber                

            };
            return User;
        }

        private UserDTO ConvertTODTO(User obj)
        {

            var UserDTO = new UserDTO()
            {
                UserID = obj.UserID,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                DOB = obj.DOB,
                Gender = obj.Gender,
                UserName = obj.UserName,
                EmailID = obj.EmailID,
                PhoneNumber = obj.PhoneNumber                

            };
            return UserDTO;
        }

      
    }
}
