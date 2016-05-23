using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fonoart.Web.Startup))]
namespace Fonoart.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
