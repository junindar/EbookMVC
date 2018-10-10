using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Latihan1.Startup))]
namespace Latihan1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
