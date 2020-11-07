using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess
{
    public interface IUserTableRepository
    {
        User SaveorUpdate(User obj);
        IEnumerable<User> GetAll();

        User GetUsersByID(int UserID);

        void DeleteUser(int USerID);

        User ValidateUser(string userName, string password);
        User GetUsersByDoctorID(int doctorID);



    }
}
