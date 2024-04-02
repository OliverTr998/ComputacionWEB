using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComputacionWEB.Startup))]
namespace ComputacionWEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
