using NHibernate;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NhibernateTutorial
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static ISessionFactory NHibernateSessionFactory;

        public override void Init()
        {
            base.Init();

            this.BeginRequest += MvcApplication_BeginRequest;

            this.EndRequest += MvcApplication_EndRequest;
        }

        private void MvcApplication_EndRequest(object sender, EventArgs e)
        {
            var session = CurrentSessionContext.Unbind(NHibernateSessionFactory);
            session.Dispose();
        }

        private void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            var session = NHibernateSessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            NHibernateSessionFactory = Configuration.NhibernateHelpers.GetNhibernateSessionFactory();
        }
    }
}
