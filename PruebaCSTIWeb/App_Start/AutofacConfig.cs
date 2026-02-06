using Autofac;
using Autofac.Integration.Mvc;
using PruebaCSTI.Application.Services;
using PruebaCSTI.Infraestructure.IoC;
using System.Reflection;
using System.Web.Mvc;

namespace PruebaCSTIWeb.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Servicios
            builder.RegisterType<InventarioService>()
                   .AsSelf()
                   .InstancePerRequest();

            // Cargar módulo de infraestructura
            builder.RegisterModule(new AutofacInfrastructureModule());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}