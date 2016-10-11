using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCBierenApplication.Startup))]
namespace MVCBierenApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
