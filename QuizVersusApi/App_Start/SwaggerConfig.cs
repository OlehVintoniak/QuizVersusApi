using System.Web.Http;
using WebActivatorEx;
using QuizVersusApi;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace QuizVersusApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "QuizVersusApi");
                        c.DescribeAllEnumsAsStrings();
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocumentTitle("QuizVersusApi");
                    });
        }
    }
}
