using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCView.Startup))]
namespace MVCView
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
