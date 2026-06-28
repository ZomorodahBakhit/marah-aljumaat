using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using University.Core.Services;

namespace University.Core.Modules
{
    public class ServiceModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(StudentService).Assembly)
              .Where(t => t.Name.EndsWith("Service"))
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();
        }
    }
}

