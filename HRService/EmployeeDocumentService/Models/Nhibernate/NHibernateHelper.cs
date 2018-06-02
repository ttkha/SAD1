using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;


namespace EmployeeDocumentService.Models.Nhibernate
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {

            var configuration = new NHibernate.Cfg.Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\Models\Nhibernate\nhibernate.cfg.xml");
            configuration.Configure(configurationPath);
            var candidateConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Models\Nhibernate\nhibernate.hbm.xml");
            configuration.AddFile(candidateConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();

        }
    }
}