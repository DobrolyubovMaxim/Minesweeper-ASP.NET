using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Minesweper.Startup))]
namespace Minesweper
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
