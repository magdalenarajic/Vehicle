using Autofac;
using Autofac.Integration.WebApi;
using DAL;
using Repository;
using Repository.Common;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using WebAPI.Modules;

namespace WebAPI.App_Start
{
    public class AutofacConfig
    {
        public static IContainer Container;
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            builder.RegisterAssemblyTypes(Assembly.Load("Repository"))
                  .Where(t => t.Name.EndsWith("Repository"))
                  .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(Assembly.Load("Service"))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
     
            builder.RegisterModule(new EFModuleDI());
            builder.RegisterModule<AutoMapperModule>();


            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }

    }
}