using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCModel.Startup))]
namespace MVCModel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
