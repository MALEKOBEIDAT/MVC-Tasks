using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_8._2._2023task.Startup))]
namespace _8._2._2023task
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
