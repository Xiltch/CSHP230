using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Assignment08.Domain.Entities;
using Assignment08.Domain.Interfaces;
using Assignment08.Domain.Processors;
using Autofac;
using Autofac.Integration.Mvc;

namespace Assignment08
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private const string connectionStringKey = "HomeServer";

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            RegisterAutofac();
        }

        private void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsSelf().AsImplementedInterfaces();

            var config = new ConfigOption()
            {
                ConnectionStringProjectContext = ConfigurationManager
                .ConnectionStrings[connectionStringKey].ToString()
            };

            builder.RegisterInstance<IConfigOption>(config);

            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            builder.RegisterType<ClassRepository>().As<IClassRepository>();

            var container = builder.Build();

            // Configure dependency resolver.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}
