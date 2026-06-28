using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using University.Data.Repositories;

namespace University.Data.Moduls
{
    public class RepositoryModules: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(StudentRepository).Assembly)
             .Where(t => t.Name.EndsWith("Repository"))
             .AsImplementedInterfaces()
             .InstancePerLifetimeScope();
        }
    }
}

