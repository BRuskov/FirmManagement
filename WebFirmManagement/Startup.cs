using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFirmManagement.Startup))]
namespace WebFirmManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
