using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NhibernateMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhibernateTutorial.Configuration
{
    public static class NhibernateHelpers
    {
        public static ISessionFactory GetNhibernateSessionFactory()
        {
            var configure = new NHibernate.Cfg.Configuration();
            configure.DataBaseIntegration(delegate(NHibernate.Cfg.Loquacious.IDbIntegrationConfigurationProperties dbi) {
                dbi.ConnectionString = "mvcWithNHibernate";
                dbi.Dialect<NHibernate.Dialect.MsSql2012Dialect>();
                dbi.Driver<NHibernate.Driver.SqlClientDriver>();
                dbi.Timeout = 255;
            });

            configure.AddAssembly(typeof(Address).Assembly);

            configure.CurrentSessionContext<WebSessionContext>();

            return configure.BuildSessionFactory();
        }
    }
}