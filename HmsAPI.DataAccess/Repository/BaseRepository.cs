using HmsAPI.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess
{
    public class BaseRepository<T> where T : class
    {

        public T SaveorUpdate(T obj)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                sessionWrapper.BeginTransaction();
                using (var session = sessionWrapper.Session)
                {
                    session.SaveOrUpdate(obj);
                    sessionWrapper.Commit();
                }
            }
            return obj;
        }

        public IEnumerable<T> GetAll()
        {

            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var results = session.QueryOver<T>().List();
                    return results;
                }
            }
        }

        public void Delete(T obj)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                sessionWrapper.BeginTransaction();
                using (var session = sessionWrapper.Session)
                {
                    session.Delete(obj);
                    sessionWrapper.Commit();
                }
            }

        }
    }
}
