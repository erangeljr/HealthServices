using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HealthServices.Web.Startup))]
namespace HealthServices.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
