using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IsItABangerWeb.Startup))]
namespace IsItABangerWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
