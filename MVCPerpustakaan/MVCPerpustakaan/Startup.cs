using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCPerpustakaan.Startup))]
namespace MVCPerpustakaan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
