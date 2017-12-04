using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EspirituSantoApp.Startup))]
namespace EspirituSantoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
