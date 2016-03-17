using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Mvc;

namespace TravelPortal.Foundations.Bootsraping
{
    public class CompositionRoot
    {
        public IContainer Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.GetInterfaces().Length > 0)
                .AsImplementedInterfaces()
                .SingleInstance();

            IContainer container = builder.Build();

            return container;
        }
    }
}
