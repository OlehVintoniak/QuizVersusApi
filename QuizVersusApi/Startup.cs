using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(QuizVersusApi.Startup))]

namespace QuizVersusApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
