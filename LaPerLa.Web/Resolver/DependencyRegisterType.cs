using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaPerLa.Web.Resolver
{
    public class DependencyRegisterType
    {
        /// <summary>
        /// 系统注入
        /// </summary>
        /// <param name="container"></param>
        public static void Container_Sys(ref UnityContainer container)
        {
            //container.RegisterType<IUserInfo, MetadataRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IControllerFactory, UnityControllerFactory>();
        }
    }
}