using Autofac;
using Autofac.Integration.WebApi;
using QuizVersusApi.Modules;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac.Integration.Mvc;

namespace QuizVersusApi
{
    public class AutoFacConfig
    {
        public static void RegisteModules()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EfModule());

            var container = builder.Build();


            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}