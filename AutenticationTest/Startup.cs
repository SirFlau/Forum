using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutenticationTest.Startup))]
namespace AutenticationTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
        }
    }
}
