using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kippenbout.Startup))]
namespace Kippenbout
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
