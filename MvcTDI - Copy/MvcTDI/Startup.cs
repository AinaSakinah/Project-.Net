using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcTDI.Startup))]
namespace MvcTDI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
