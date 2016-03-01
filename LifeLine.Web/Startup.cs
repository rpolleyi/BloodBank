using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LifeLine.Web.Startup))]
namespace LifeLine.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var config = new HubConfiguration
            {
                EnableJavaScriptProxies = true
            };
            app.MapSignalR(config);
        }
    }
}
