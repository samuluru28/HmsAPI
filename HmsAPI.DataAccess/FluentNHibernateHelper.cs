using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HmsAPI.Model;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HmsAPI.DataAccess
{
    public class FluentNHibernateHelper : IDisposable
    {

        private ISession _session;
        public ISession Session
        {
            get
            {
                if (Session == null)
                {
                    var SessionFactory = GetSessionFactory();

                    Session = SessionFactory.OpenSession();
                }

                return _session;
            }
            private set 
            {
                _session = value;
            }
        }
        public readonly string connectionString;
        public FluentNHibernateHelper()
        {
            connectionString = "Server = DESKTOP-IIGBN65; Database = HMS; Trusted_Connection = True";

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private ISessionFactory GetSessionFactory()
        {
            ISessionFactory sessionFactory = Fluently.Configure()

               .Database(MsSqlConfiguration.MsSql2012

                 .ConnectionString(connectionString).ShowSql()

               )

               .Mappings(m =>

                         m.FluentMappings

                             .AddFromAssemblyOf<UserTable>())

               .ExposeConfiguration(cfg => new SchemaExport(cfg)

                .Create(false, false))

               .BuildSessionFactory();

            return sessionFactory;
        }

        public void Open()
        {           
            
        }


    }
}
