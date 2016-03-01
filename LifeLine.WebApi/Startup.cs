using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LifeLine.WebApi.Startup))]
namespace LifeLine.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
