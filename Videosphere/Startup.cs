using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Videosphere.Startup))]
namespace Videosphere
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
