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
        protected ISession _session = null;
        protected ITransaction _transaction = null;
        public BaseRepository()
        {
            _session = FluentNHibernateHelper.OpenSession();
        }
        public BaseRepository(ISession session)
        {
            _session = session;
        }
        public T SaveorUpdate(T obj)
        {
           // var session = FluentNHibernateHelper.OpenSession();
            var transaction = _session.BeginTransaction();
            _session.SaveOrUpdate(obj);
            transaction.Commit();
            return obj;
        }

        public IEnumerable<T> GetAll()
        {
            var session = FluentNHibernateHelper.OpenSession();
            var results = session.QueryOver<T>().List();
            return results;

        }

        public void Delete(T obj)
        {
            var session = FluentNHibernateHelper.OpenSession();
            var transaction = session.BeginTransaction();
            session.Delete(obj);
            transaction.Commit();

        }

        public void RollbackTransaction()
        {
            _transaction.Rollback();
            CloseTransaction();
            CloseSession();
        }
        private void CloseTransaction()
        {
            _transaction.Dispose();
            _transaction = null;
        }
        private void CloseSession()
        {
            _session.Close();
            _session.Dispose();
            _session = null;
        }
    }
}
