using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebShop_Rest.Startup))]
namespace WebShop_Rest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
