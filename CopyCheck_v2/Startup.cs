using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CopyCheck_v2.Startup))]
namespace CopyCheck_v2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
