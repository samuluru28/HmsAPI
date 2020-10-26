using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess
{
    public class HibernateFactoryProvider
    {
        static FluentNHibernateHelper NHibernateHelper;
        private static FluentNHibernateHelper FluentNHibernateHelper
        {
            get
            {
                if(NHibernateHelper == null)
                {
                    NHibernateHelper = new FluentNHibernateHelper();
                }
                return NHibernateHelper;
            }
        }

        public static ISession CreateSession()
        {
            ISession session = null;

            session = NHibernateHelper.GetSessionFactory().OpenSession();
            return session;
        }
    }
}
