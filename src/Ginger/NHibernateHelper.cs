using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Ginger
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)

                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(
                        c => c.FromConnectionStringWithKey("Ginger"))
                    .ShowSql()
                )
                .Mappings(m =>
                    m.FluentMappings
                        .AddFromAssemblyOf<MainForm>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg))
                .Diagnostics(d => d.Enable().OutputToConsole())
                .BuildSessionFactory();

        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
