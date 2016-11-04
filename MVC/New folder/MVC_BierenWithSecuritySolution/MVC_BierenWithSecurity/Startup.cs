using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_BierenWithSecurity.Startup))]
namespace MVC_BierenWithSecurity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
