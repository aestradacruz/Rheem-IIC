using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ICI.Startup))]
namespace ICI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
