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
        UserTable SaveorUpdate(UserTable obj);
        IEnumerable<UserTable> GetAll();

        UserTable GetUsersByID(int UserID);

        void DeleteUser(int USerID);



    }
}
