using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaPerLa.Model;
using NHibernate;
using NHibernate.Cfg;

namespace LaPerLa.MetadataAccess
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if(_sessionFactory == null)
                {
                    var config = new Configuration();
                    config.Configure();
                    config.AddAssembly(typeof (DistrictInfo).Assembly);
                    _sessionFactory = config.BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}