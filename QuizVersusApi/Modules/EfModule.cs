using Autofac;
using QuizVersus.Core.Data;
using QuizVersus.Core.Repositories;

namespace QuizVersusApi.Modules
{
    public class EfModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new ServiceModule());

            builder.RegisterType(typeof(ApplicationDbContext)).As(typeof(ApplicationDbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
        }
    }
}