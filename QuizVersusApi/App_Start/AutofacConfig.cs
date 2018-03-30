using Autofac;
using Autofac.Integration.WebApi;
using QuizVersusApi.Modules;
using System.Reflection;
using System.Web.Http;

namespace QuizVersusApi
{
    public class AutoFacConfig
    {
        public static void RegisteModules()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EfModule());

            var container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}