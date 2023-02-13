using Autofac;
using Repository;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebAPI.Modules
{
    public class RepositoryModuleDI : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("Repository"))
                  .Where(t => t.Name.EndsWith("Repository"))
                  .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();
        }
    }
}