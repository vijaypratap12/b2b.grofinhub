using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gropnew.Startup))]
namespace gropnew
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
