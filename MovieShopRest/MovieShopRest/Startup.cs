using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieShopRest.Startup))]
namespace MovieShopRest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
