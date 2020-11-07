using HmsAPI.Model;
using System.Linq;

namespace HmsAPI.DataAccess
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public void DeleteUser(int UserID)
        {
            var objUser = GetUsersByID(UserID);
            Delete(objUser);   
          
        }

        public User GetUsersByID(int userID)
        {

            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var objUser = session.Query<User>().Where(x => x.UserID == userID).FirstOrDefault();
                    return objUser;
                }
            }
        }

        public User ValidateUser(string userName,string password)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var objUser = session.Query<User>().Where(x => x.UserName == userName && x.Password == password) .FirstOrDefault();
                    return objUser;
                }
            }


        }

    
        public User GetUsersByDoctorID(int doctorID)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var query = "select u.* from UserTable u join Doctor d on u.UserID = d.UserId where d.DoctorID =" + doctorID;

                    var results = session.CreateSQLQuery(query).AddEntity(typeof(User)).List<User>().FirstOrDefault();
                    return results;
                }

            }
        }
    }
}
