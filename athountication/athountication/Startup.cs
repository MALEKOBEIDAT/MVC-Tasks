using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(athountication.Startup))]
namespace athountication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
