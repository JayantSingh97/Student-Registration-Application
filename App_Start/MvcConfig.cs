using EducareApplication.Educareervice.Implementation;
using EducareApplication.EducareService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;

namespace EducareApplication.App_Start
{
    public class MvcConfig
    {
        public static void RegisterDependencyInjection()
        {
            var container = new UnityContainer();

            container.RegisterType<IEducareService, Educareservice>(new HierarchicalLifetimeManager());

            DependencyResolver.SetResolver(new UnityResolver(container));
        }
    }
}
