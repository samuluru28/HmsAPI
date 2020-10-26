using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess
{
    public class SessionWrapper : IDisposable
    {
        private bool disposedValue;

        public SessionWrapper()
        {
            Session = HibernateFactoryProvider.CreateSession();            
        }

        public ISession Session { get; private set; } = null;

        public void BeginTransaction()
        {
            Session.BeginTransaction();
        }

        public void Commit()
        {
            Session.Transaction.Commit();
        }

        private void RollBack()
        {
            if(Session.Transaction!=null && Session.Transaction.IsActive 
                && !Session.Transaction.WasCommitted && !Session.Transaction.WasRolledBack)
            {
                Session.Transaction.Rollback();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }
                if (Session != null)
                {
                    RollBack();
                }
                Session.Dispose();
                Session = null;
                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~SessionWrapper()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
