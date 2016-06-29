using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YMB.Startup))]
namespace YMB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
