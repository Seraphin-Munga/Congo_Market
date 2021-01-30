using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Congo_Market_Web.Startup))]
namespace Congo_Market_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
