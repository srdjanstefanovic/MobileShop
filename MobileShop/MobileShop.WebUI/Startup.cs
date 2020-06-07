using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MobileShop.WebUI.Startup))]
namespace MobileShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
