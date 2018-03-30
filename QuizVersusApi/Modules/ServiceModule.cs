using Autofac;
using QuizVersus.Core.Services.Factory;

namespace QuizVersusApi.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(ServiceManager)).As(typeof(IServiceManager)).InstancePerLifetimeScope();
        }
    }
}