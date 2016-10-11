using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Voorbeeld1.Startup))]
namespace MVC_Voorbeeld1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
