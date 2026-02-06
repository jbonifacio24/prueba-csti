using System;
using System.Collections.Generic;
using System.Linq;
//using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using PruebaCSTI.Domain.Interfaces;
using PruebaCSTI.Infraestructure.Repositories;


namespace PruebaCSTI.Infraestructure.IoC
{
    public class AutofacInfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InventarioRepository>()
                   .As<IInventarioRepository>()
                   .InstancePerRequest();
        }
    }
}
